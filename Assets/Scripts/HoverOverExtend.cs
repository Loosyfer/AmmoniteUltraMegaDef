using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOverExtend : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public void Enter()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(9.17f, 2.47f, 0);
    }

    public void Exit()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(1.74f, 2.47f, 0);
    }
}
