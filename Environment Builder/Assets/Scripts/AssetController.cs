using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AssetController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scaleRate;

    private Vector3 _mousePosOffset;

    private float _mouseZCoord;

    private CommandManager _commandManager;
    

    private void Start()
    {
        _commandManager = GameObject.FindObjectOfType<CommandManager>();
    }

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
            _commandManager.ExecuteCommand(new CommandRotate(this.transform));            
        }
        

        if(InputManager.Instance.GetKeyPressed(KeyCode.X))
        {
            transform.Rotate(Vector3.up * -_rotationSpeed * Time.deltaTime);
            _commandManager.ExecuteCommand(new CommandRotate(this.transform));  
        }  
    }

    private void ScaleAsset()
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        if(InputManager.Instance.GetKeyPressed(KeyCode.C))
        {
            transform.localScale += new Vector3(_scaleRate, _scaleRate, _scaleRate);
            _commandManager.ExecuteCommand(new CommandScale(this.transform));
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.V))
        {
            transform.localScale -= new Vector3(_scaleRate, _scaleRate, _scaleRate);
            _commandManager.ExecuteCommand(new CommandScale(this.transform));
        }
    }
}
