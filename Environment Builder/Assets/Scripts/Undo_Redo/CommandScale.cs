using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScale : IAction
{
    private Transform _assetToScale;
    private float _scaleFactor;

    public CommandScale(Transform assetToScale, float scaleFactor)
    {
        _assetToScale = assetToScale;
        _scaleFactor = scaleFactor;
    }

    public void ExecuteCommand()
    {
        if(_assetToScale == null) return;

        _assetToScale.localScale += new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
    }

    public void UndoCommand()
    {
        if(_assetToScale == null) return;

        _assetToScale.localScale -= new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);
    }
}
