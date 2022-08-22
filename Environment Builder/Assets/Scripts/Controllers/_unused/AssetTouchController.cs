using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetTouchController : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID

    [SerializeField]
    // private float _holdTime = 3f;
    // private float _startTime = 0f;
    // private float _timer = 0f;

    // [SerializeField]private bool _timerStarted;
    // [SerializeField]private bool _held;
    // [SerializeField]private bool _camControllerActivated = true;

    private Vector3 _touchPosOffset;

    private float _touchZCoord;

    // private GameCameraTouchController _camTouchController;

    private void Awake() 
    {
        // AssetController assetController = GetComponent<AssetController>();
        // assetController.enabled = false;

        // _camTouchController = GameObject.FindObjectOfType<GameCameraTouchController>();
    }

    private void Update()
    {
        
    }

    private void SetTouchOffset()
    {
        _touchZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        _touchPosOffset = gameObject.transform.position - GetTouchWorldPosition();
    }

    private Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPoint = Input.GetTouch(0).position;

        //touchPoint.z = _touchZCoord;

        return Camera.main.ScreenToWorldPoint(touchPoint);
    }

    // private void AcivateCameraTouchController(bool activate)
    // {
    //     _camTouchController.SetCamActivator(activate);
    // }

    // public void ResetTimer()
    // {
    //     _timerStarted = false;
    //     _held = false;
    //     _timer = 0f;
    // }

    // public void ActivateTouchOnAsset() 
    // {
    //     if(!_timerStarted)
    //     {
    //         _startTime = Time.time;
    //         _timer = _startTime;
    //         _timerStarted = true;
    //     }

    //     if(!_held && _timerStarted)
    //     {
    //          _timer += Time.deltaTime;

    //         if(_timer > (_startTime + _holdTime))
    //         {
    //             _held = true;
                
    //             //ResetTimer();
    //             SetTouchOffset();
    //             AcivateCameraTouchController(!_camControllerActivated);

    //             _camControllerActivated = !_camControllerActivated;
    //         }
    //     }
    // }

    // public bool GetAssetHeld()
    // {
    //     return _held;
    // }

#endif
}
