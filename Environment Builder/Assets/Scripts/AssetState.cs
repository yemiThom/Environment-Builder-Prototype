using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AssetState
{
    private Transform _assetTransform;

    private Vector3 _assetLocalposition;
    private Quaternion _assetLocalRotation;
    private Vector3 _assetLocalScale;

    private bool _assetActive;

    public AssetState(GameObject obj)
    {
        _assetTransform = obj.transform;

        _assetLocalposition = obj.transform.localPosition;
        _assetLocalRotation = obj.transform.localRotation;
        _assetLocalScale = obj.transform.localScale;

        _assetActive = obj.activeSelf;
    }

    public void ApplyAssetState(GameObject obj)
    {
        obj.transform.localPosition = _assetLocalposition;
        obj.transform.localRotation = _assetLocalRotation;
        obj.transform.localScale = _assetLocalScale;

        obj.transform.gameObject.SetActive(_assetActive);
    }
}
