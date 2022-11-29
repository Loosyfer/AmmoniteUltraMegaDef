using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOverExtend : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(380, 25);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(33.9f, 12.7f, 0);
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(178, 25);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.8f, 12.7f, 0);
    }
}
