using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AllAssetsData
{
    public AssetDataState[] assetDataStates;

    public AllAssetsData(AssetDataState[] dataStates)
    {
        this.assetDataStates = dataStates;
    }
}
