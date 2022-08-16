using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        UpdateSelectedAsset();
        DeleteSelectedAsset();

        if(InputManager.Instance.GetKeyPressed(KeyCode.L))
        {
            DeleteAllAssets();
        }
    }

    private void UpdateSelectedAsset()
    {
        if(GetMouseButtonPressed(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag.Contains("SelectableAsset"))
                {
                    GameController.Instance.SetSelectedAsset(hit.transform.gameObject);
                }
                else
                {
                    GameController.Instance.SetSelectedAsset(null);
                }
            }
        }
    }

    private void DeleteSelectedAsset()
    {
        if(GameController.Instance.GetSelectedAsset() == null) return;

        if(GetKeyPressed(KeyCode.Delete))
        {
            GameController.Instance.RemoveFromSpawnedAssetsList(GameController.Instance.GetSelectedAsset());
            Destroy(GameController.Instance.GetSelectedAsset());
        }
    }
    
    private void DeleteAllAssets()
    {
        foreach (GameObject asset in GameController.Instance.GetSpawnedAssetList())
        {
            Destroy(asset);
        }

        GameController.Instance.ResetSpawnedAssetList();
    }

    public bool GetKeyPressed(KeyCode keycode)
    {
        return Input.GetKey(keycode);
    }

    public bool GetMouseButtonPressed(int buttonPressed)
    {
        return Input.GetMouseButton(buttonPressed);
    }
}
