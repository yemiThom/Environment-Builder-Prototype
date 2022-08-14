using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    [SerializeField] private GameObject _selectedAsset;

    private void Start()
    {
        
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
}
