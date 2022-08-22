using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRotate : IAction
{   
    private Transform _assetToRotate;
    private Vector3 _rotationToAdd;

    public CommandRotate(Transform assetToRotate, Vector3 rotationToAdd)
    {
        _assetToRotate = assetToRotate;
        _rotationToAdd = rotationToAdd;
    }

    public void ExecuteCommand()
    {
        if(_assetToRotate == null) return;

        _assetToRotate.Rotate(_rotationToAdd);
    }

    public void UndoCommand()
    {
        if(_assetToRotate == null) return;
        
        _assetToRotate.Rotate(-_rotationToAdd);
    }
}