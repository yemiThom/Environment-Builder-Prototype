using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] _subMenuCGs;

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

    public void TurnOffAllSubMenuCGs()
    {
        foreach (CanvasGroup cg in _subMenuCGs)
        {
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts  = false;
        }
    }
}
