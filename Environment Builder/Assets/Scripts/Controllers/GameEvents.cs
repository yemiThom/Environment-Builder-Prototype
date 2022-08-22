using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() 
    {
        current = this;
    }

    // public event Action onDeleteAssetPressed;

    // public void DeleteAssetPressed()
    // {
    //     if(onDeleteAssetPressed == null) return;

    //     onDeleteAssetPressed();
    // }

    // public event Action<int> onEvergreenButtonPressed;

    // public void EvergreenButtonPressed()
    // {
    //     if(onEvergreenButtonPressed == null) return;

    //     onEvergreenButtonPressed();
    // }
}
