using UnityEngine;

public class GameCameraTouchController : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID

    [SerializeField] private Camera _camera;
    [SerializeField] private bool _rotate;
    [SerializeField] protected Plane Plane;

    [SerializeField] private float _decreaseCameraPanSpeed = 1;
    [SerializeField] private float _cameraUpperHeightBound;
    [SerializeField] private float _cameraLowerHeightBound;

    private Vector3 _cameraStartPosition;

    [SerializeField]private bool _activateCameraControls = true;

    private void Awake() {
        GameCameraController keyboardControls = GetComponent<GameCameraController>();
        keyboardControls.enabled = false;

        if(_camera == null)
            _camera = Camera.main;

        _cameraStartPosition = _camera.transform.position;
    }

    private void Update()
    {
        if(_activateCameraControls)
        {
            // Update Plane
            if(Input.touchCount >= 1)
                Plane.SetNormalAndPosition(transform.up, transform.position);

            var Delta1 = Vector3.zero;
            var Delta2 = Vector3.zero;

            // Panning Functionality
            if(Input.touchCount >= 1)
            {
                // Get distance the camera should travel
                Delta1 = PlanePositionDelta(Input.GetTouch(0))/_decreaseCameraPanSpeed;

                if(Input.GetTouch(0).phase == TouchPhase.Moved)
                    _camera.transform.Translate(Delta1, Space.World);
            }

            // Pinch Zoom Functionality
            if(Input.touchCount >= 2)
            {
                var pos1 = PlanePosition(Input.GetTouch(0).position);
                var pos2 = PlanePosition(Input.GetTouch(1).position);
                var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                // Calculate the zoom
                var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1b, pos2b);

                // Rule out edge case
                if(zoom == 0 || zoom > 10)
                    return;

                // Move camera amount of the mid ray
                Vector3 camPositionBeforeAdjustment = _camera.transform.position;
                _camera.transform.position = Vector3.LerpUnclamped(pos1, _camera.transform.position, 1/zoom);

                // Restrict zoom height
                // if(_camera.transform.position.y > (_cameraStartPosition.y + _cameraUpperHeightBound))
                // {
                //     _camera.transform.position = camPositionBeforeAdjustment;
                // }

                // if(_camera.transform.position.y < (_cameraStartPosition.y - _cameraLowerHeightBound) || _camera.transform.position.y <= 1)
                // {
                //     _camera.transform.position = camPositionBeforeAdjustment;
                // }

                // Rotation functionality
                if(_rotate && pos2b != pos2)
                    _camera.transform.RotateAround(pos1, Plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, Plane.normal));
            }
        }
    }

    // Returns the point between first and second finger position
    protected Vector3 PlanePositionDelta(Touch touch)
    {
        // If not moved
        if(touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        // Get delta
        var rayBefore = _camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = _camera.ScreenPointToRay(touch.position);
        
        if(Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        // If not on plane
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        // Position
        var rayNow = _camera.ScreenPointToRay(screenPos);
        if(Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    public void SetCamActivator(bool activate)
    {
        _activateCameraControls = activate;
    }

#endif
}
