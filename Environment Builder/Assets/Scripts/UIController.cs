using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateCanvasGroupState(CanvasGroup cg)
    {
        if(cg.alpha == 0)
        {
            cg.alpha = 1;
        }
        else
        {
            cg.alpha = 0;
        }

        cg.interactable = !cg.interactable;
        cg.blocksRaycasts  = !cg.blocksRaycasts;
    }
}
