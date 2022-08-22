using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private List<GameObject> _allSpawnedAssets;
    [SerializeField] private AssetController[] _assetControllers;

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
        if(InputManager.Instance.GetKeyPressed(KeyCode.K))
        {
            Save();
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.L))
        {
            Load();
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.Backspace))
        {
            DeleteSelectedAsset();
        }

        if(InputManager.Instance.GetKeyPressed(KeyCode.Delete))
        {
            DeleteAllAssets();
        }
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

    public void RemoveFromSpawnedAssetsList(GameObject spawnedAsset)
    {
        _allSpawnedAssets.Remove(spawnedAsset);
    }

    public List<GameObject> GetSpawnedAssetList()
    {
        return _allSpawnedAssets;
    }

    public void ResetSpawnedAssetList()
    {
        _allSpawnedAssets = new List<GameObject>();
    }  

    public void RotateAssetByDegrees(float degrees)
    {
        if(GetSelectedAsset() == null) return;
        
        GetSelectedAsset().GetComponent<AssetController>().SnapRotateAsset(degrees);
    }  

    public void DeleteSelectedAsset()
    {
        if(GetSelectedAsset() == null) return;
        
        RemoveFromSpawnedAssetsList(GetSelectedAsset());
        Destroy(GetSelectedAsset());
    }
    
    public void DeleteAllAssets()
    {
        foreach (GameObject asset in GetSpawnedAssetList())
        {
            Destroy(asset);
        }

        ResetSpawnedAssetList();
    }

    public void Save()
    {
        Debug.Log("Saving...");

        if(_assetControllers.Length == 0)
        {
            _assetControllers = new AssetController[_allSpawnedAssets.Count];
        }

        for (int i = 0; i < _allSpawnedAssets.Count; i++)
        {
            _assetControllers[i] = _allSpawnedAssets[i].transform.GetComponent<AssetController>();
        }

        SaveSystem.Save(_assetControllers);
    }

    public void Load()
    {
        Debug.Log("Loading...");

        DeleteAllAssets();

        AllAssetsData dataStates = SaveSystem.Load();

        for (int i = 0; i < dataStates.assetDataStates.Length; i++)
        {
            GameObject loadedAsset = Instantiate(Resources.Load(dataStates.assetDataStates[i]._assetName)) as GameObject;
            
            AddToSpawnedAssetsList(loadedAsset);

            Vector3 assetPos = new Vector3(
                dataStates.assetDataStates[i]._assetPosition[0],
                dataStates.assetDataStates[i]._assetPosition[1],
                dataStates.assetDataStates[i]._assetPosition[2]
            );
            Quaternion assetRot = new Quaternion(
                dataStates.assetDataStates[i]._assetRotation[0],
                dataStates.assetDataStates[i]._assetRotation[1],
                dataStates.assetDataStates[i]._assetRotation[2],
                dataStates.assetDataStates[i]._assetRotation[3]
            );
            Vector3 assetScale = new Vector3(
                dataStates.assetDataStates[i]._assetScale[0],
                dataStates.assetDataStates[i]._assetScale[1],
                dataStates.assetDataStates[i]._assetScale[2]
            );

            loadedAsset.transform.position = assetPos;
            loadedAsset.transform.rotation = assetRot;
            loadedAsset.transform.localScale = assetScale;
        }
    }
}
