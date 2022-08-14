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
            Destroy(GameController.Instance.GetSelectedAsset());
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
