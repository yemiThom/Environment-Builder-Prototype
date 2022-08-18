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

    public bool GetKeyPressed(KeyCode keycode)
    {
        return Input.GetKey(keycode);
    }

    public bool GetMouseButtonPressed(int buttonPressed)
    {
        return Input.GetMouseButton(buttonPressed);
    }
}
