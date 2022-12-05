using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOver : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        HoverPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        HoverPanel.SetActive(false);
    }
}
