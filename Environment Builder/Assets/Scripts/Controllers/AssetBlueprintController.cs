using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBlueprintController : MonoBehaviour
{
    [SerializeField] private GameObject _assetPrefab;

    [SerializeField] private bool _canRotate = true;

    private Vector3 _movePoint;

    private RaycastHit hit;

    private CommandManager _commandManager;

    private void Start()
    {
        _commandManager = GameObject.FindObjectOfType<CommandManager>();
        MoveToHitPosition();
    }

    private void Update()
    {
        MoveToHitPosition();
        SpawnAtPosition();
        ExitBlueprintSpawner();
    }

    private void MoveToHitPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            transform.position = hit.point;

            if(!_canRotate)  return;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }

    private void SpawnAtPosition()
    {
        if(InputManager.Instance.GetMouseButtonPressed(0))
        {
            CommandInstantiate commandInstantiate = new CommandInstantiate(_assetPrefab, transform.position, transform.rotation);
            _commandManager.ExecuteCommand(commandInstantiate);

            GameObject spawnedAsset = commandInstantiate.GetSpawnedAsset();

            spawnedAsset.name = _assetPrefab.name;

            GameController.Instance.SetSelectedAsset(spawnedAsset);
            GameController.Instance.AddToSpawnedAssetsList(spawnedAsset);

            Destroy(gameObject);
        }
    }

    private void ExitBlueprintSpawner()
    {
        if(InputManager.Instance.GetMouseButtonPressed(1))
        {
            Destroy(gameObject);
        }
    }
}
