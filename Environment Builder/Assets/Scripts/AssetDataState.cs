using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AssetDataState
{
    public float[] _assetPosition;
    public float[] _assetRotation;
    public float[] _assetScale;
    public string _assetName;

    public AssetDataState(AssetController asset)
    {
        Vector3 assetPos = asset.transform.position;
        Quaternion assetRot = asset.transform.rotation;
        Vector3 assetScale = asset.transform.localScale;
        string assetName = asset.transform.gameObject.name;

        _assetPosition = new float[]{assetPos.x, assetPos.y, assetPos.z};
        _assetRotation = new float[]{assetRot.x, assetRot.y, assetRot.z, assetRot.w};
        _assetScale = new float[]{assetScale.x, assetScale.y, assetScale.z};
        _assetName = assetName;
    }
}