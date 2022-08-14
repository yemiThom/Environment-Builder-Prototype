using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private List<GameObject> _allSpawnedAssets;

    private void Awake() {
        Instance = this;
    }

    [SerializeField] private GameObject _selectedAsset;

    private void Start()
    {
        _allSpawnedAssets = new List<GameObject>();
    }

    private void Update()
    {
        
    }

    public GameObject GetSelectedAsset()
    {
        return _selectedAsset;
    }

    public void SetSelectedAsset(GameObject newSelectedAsset)
    {
        _selectedAsset = newSelectedAsset;
    
    }

    public void AddToSpawnedAssetsList(GameObject newSpawnedAsset)
    {
        _allSpawnedAssets.Add(newSpawnedAsset);
    }

    public List<GameObject> GetSpawnedAssetList()
    {
        return _allSpawnedAssets;
    }

    public void ResetSpawnedAssetList()
    {
        _allSpawnedAssets = new List<GameObject>();
    }
}
