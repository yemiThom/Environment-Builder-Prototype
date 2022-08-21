using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRotate : IAction
{   
    private Transform _assetToRotate;
    private Quaternion _assetRotation;

    public CommandRotate(Transform assetToRotate)
    {
        _assetToRotate = assetToRotate;
        _assetRotation = assetToRotate.rotation;
    }

    public void ExecuteCommand()
    {
        SetAssetRotation();
    }

    public void UndoCommand()
    {
        SetAssetRotation();
    }

    private void SetAssetRotation()
    {
        _assetToRotate.rotation = _assetRotation;
    }
}