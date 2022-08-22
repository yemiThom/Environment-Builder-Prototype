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
        CheckTouchedAsset();
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
                else if(hit.transform.tag.Contains("Untagged"))
                {
                    GameController.Instance.SetSelectedAsset(null);
                }
            }
        }


    }

    private void CheckTouchedAsset()
    {
        if(Input.touchCount > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject == GameController.Instance.GetSelectedAsset())
                {
                    AssetTouchController touchController = hit.transform.GetComponent<AssetTouchController>();

                    if(touchController.GetAssetHeld())
                        touchController.ResetTimer();
                    
                    touchController.ActivateTouchOnAsset();
                }
            }
        }
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
