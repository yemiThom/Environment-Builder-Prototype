using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AssetController : MonoBehaviour
{   
#if UNITY_EDITOR

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scaleRate;

    private Vector3 _mousePosOffset;

    private float _mouseZCoord;

    private void Update()
    {
        RotateAsset();
        ScaleAsset();
    }

    private void OnMouseDown() 
    {
        _mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        _mousePosOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag() 
    {
        transform.position = GetMouseWorldPosition() + _mousePosOffset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = _mouseZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void RotateAsset()
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        if(InputManager.Instance.GetKeyPressed(KeyCode.Z))
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.X))
        {
            transform.Rotate(Vector3.up * -_rotationSpeed * Time.deltaTime);
        }  
    }

    private void ScaleAsset()
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        if(InputManager.Instance.GetKeyPressed(KeyCode.C))
        {
            transform.localScale += new Vector3(_scaleRate, _scaleRate, _scaleRate);
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.V))
        {
            transform.localScale -= new Vector3(_scaleRate, _scaleRate, _scaleRate);
        }
    }
#endif
}
