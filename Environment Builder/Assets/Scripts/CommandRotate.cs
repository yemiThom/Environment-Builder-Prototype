using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRotate : IAction
{   
    private Transform _assetToRotate;
    private Quaternion _assetRotation;
    private Vector3 _rotationToAdd;

    public CommandRotate(Transform assetToRotate, Vector3 rotationToAdd)
    {
        _assetToRotate = assetToRotate;
        _assetRotation = assetToRotate.rotation;
        _rotationToAdd = rotationToAdd;
    }

    public void ExecuteCommand()
    {
        //SetAssetRotation();
        _assetToRotate.Rotate(_rotationToAdd);
    }

    public void UndoCommand()
    {
        //SetAssetRotation();
        _assetToRotate.Rotate(-_rotationToAdd);
    }

    private void SetAssetRotation()
    {
        _assetToRotate.rotation = _assetRotation;
    }
}