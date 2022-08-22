using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    
#if UNITY_EDITOR

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _fastSpeed;
    [SerializeField] private float _movementTime;
    [SerializeField] private float _rotation;

    [SerializeField] private Vector3 _zoomAmount;
    private Vector3 _newZoom;
    private bool _zoomedIn;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;

    private Vector3 _newPosition;
    private Quaternion _newRotation;

    [SerializeField] private Transform _cameraTransform;
    
    private void Start()
    {
        InitialiseCamera();
    }

    private void Update()
    {
        HandleKeyboardInput();
    }

    private void InitialiseCamera()
    {
        if(_cameraTransform == null)
        {
            _cameraTransform = transform.GetChild(0);
        }

        _newPosition = transform.position;
        _newRotation = transform.rotation;
        _newZoom = _cameraTransform.localPosition;
    }

    private void HandleKeyboardInput()
    {
        if(_zoomedIn)
        {
            _movementSpeed = _normalSpeed;
        }else{
            _movementSpeed = _fastSpeed;
        }

        // Pan foward, back, left and right
        if(InputManager.Instance.GetKeyPressed(KeyCode.W) || InputManager.Instance.GetKeyPressed(KeyCode.UpArrow))
        {
            _newPosition += (transform.forward * _movementSpeed);
        }
        if(InputManager.Instance.GetKeyPressed(KeyCode.S) || InputManager.Instance.GetKeyPressed(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -_movementSpeed);
        }
        if(InputManager.Instance.GetKeyPressed(KeyCode.A) || InputManager.Instance.GetKeyPressed(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * -_movementSpeed);
        }
        if(InputManager.Instance.GetKeyPressed(KeyCode.D) || InputManager.Instance.GetKeyPressed(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * _movementSpeed);
        }

        // Rotate around world position
        if(InputManager.Instance.GetKeyPressed(KeyCode.Q))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * _rotation);
        }
        if(InputManager.Instance.GetKeyPressed(KeyCode.E))
        {
            _newRotation *= Quaternion.Euler(Vector3.up * -_rotation);
        }

        // Zoom in and out by updating the childed camera object's local position
        if(InputManager.Instance.GetKeyPressed(KeyCode.R))
        {
            _newZoom += _zoomAmount;
            _zoomedIn = true;
        }
        if(InputManager.Instance.GetKeyPressed(KeyCode.F))
        {
            _newZoom -= _zoomAmount;
            _zoomedIn = false;
        }

        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _movementTime);

        _newZoom.y = Mathf.Clamp(_newZoom.y, _minZoom, _maxZoom);
        _newZoom.z = Mathf.Clamp(_newZoom.z, -_maxZoom, -_minZoom);
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, _newZoom, Time.deltaTime * _movementTime);
    }
#endif
}
