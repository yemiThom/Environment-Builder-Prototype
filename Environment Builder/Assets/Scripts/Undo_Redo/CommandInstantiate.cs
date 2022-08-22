using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInstantiate : IAction
{
    private GameObject _assetToSpawn;
    private Vector3 _spawnPosition;
    private Quaternion _spawnRotation;

    private GameObject _spawnedAsset;
    
    public CommandInstantiate(GameObject assetToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        _assetToSpawn = assetToSpawn;
        _spawnPosition = spawnPosition;
        _spawnRotation = spawnRotation;
    }

    public void ExecuteCommand()
    {
        _spawnedAsset = GameObject.Instantiate(_assetToSpawn, _spawnPosition, _spawnRotation);
    }

    public void UndoCommand()
    {
        GameObject.Destroy(_spawnedAsset);
    }

    public GameObject GetSpawnedAsset()
    {
        return _spawnedAsset;
    }
}
