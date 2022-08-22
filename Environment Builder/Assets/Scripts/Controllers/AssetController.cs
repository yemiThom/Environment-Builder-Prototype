using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AssetController : MonoBehaviour
{

    [SerializeField] private float _rotationDegrees;
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
            Vector3 rotationToAdd = new Vector3(0, -_rotationDegrees, 0);
            _commandManager.ExecuteCommand(new CommandRotate(this.transform, rotationToAdd));            
        }
        

        if(InputManager.Instance.GetKeyPressed(KeyCode.X))
        {
            Vector3 rotationToAdd = new Vector3(0, _rotationDegrees, 0);
            _commandManager.ExecuteCommand(new CommandRotate(this.transform, rotationToAdd));  
        }  
    }

    private void ScaleAsset()
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        if(InputManager.Instance.GetKeyPressed(KeyCode.C))
        {
            //transform.localScale += new Vector3(_scaleRate, _scaleRate, _scaleRate);
            _commandManager.ExecuteCommand(new CommandScale(this.transform, _scaleRate));
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.V))
        {
            //transform.localScale -= new Vector3(_scaleRate, _scaleRate, _scaleRate);
            _commandManager.ExecuteCommand(new CommandScale(this.transform, _scaleRate));
        }
    }

    public void SnapRotateAsset(float degrees)
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        Vector3 rotationToAdd = new Vector3(0, degrees, 0);
        _commandManager.ExecuteCommand(new CommandRotate(this.transform, rotationToAdd));
    }

    public void SnapScaleAsset(float scaleFactor)
    {
        if(GameController.Instance.GetSelectedAsset() != this.gameObject) return;

        _commandManager.ExecuteCommand(new CommandScale(this.transform, scaleFactor));
    }
}
