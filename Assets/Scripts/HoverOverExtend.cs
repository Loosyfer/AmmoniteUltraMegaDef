using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOverExtend : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public void OnMouseOver()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.0841f, 2.98f, 0);
    }

    public void OnMouseExit()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(62.5f, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.0841f, 2.98f, 0);
    }
}
