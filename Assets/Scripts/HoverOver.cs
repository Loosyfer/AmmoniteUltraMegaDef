using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOver : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverPanel;

    public void OnMouseOver()
    {
        HoverPanel.SetActive(true);
    }

    public void OnMouseExit()
    {
        HoverPanel.SetActive(false);
    }
}
