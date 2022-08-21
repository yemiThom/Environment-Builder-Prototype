using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScale : IAction
{
    private Transform _assetToScale;
    private Vector3 _assetScale;

    public CommandScale(Transform assetToScale)
    {
        _assetToScale = assetToScale;
        _assetScale = assetToScale.localScale;
    }

    public void ExecuteCommand()
    {
        SetAssetScale();
    }

    public void UndoCommand()
    {
        SetAssetScale();
    }

    private void SetAssetScale()
    {
        _assetToScale.localScale = _assetScale;
    }
}
