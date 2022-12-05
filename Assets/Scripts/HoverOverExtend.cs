using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOverExtend : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public void Enter()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(380, 25);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(39.82f, 12.7f, 0);
    }

    public void Exit()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(178, 25);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(5.6f, 12.7f, 0);
    }
}
