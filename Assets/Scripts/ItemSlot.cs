using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.transform.tag == "Member")
                eventData.pointerDrag.transform.position = transform.position - new Vector3(0, 18.4f, 0);
            if (eventData.pointerDrag.transform.tag == "Module")
                eventData.pointerDrag.transform.position = transform.position;
            //GetComponent<RectTransform>().anchoredPosition
        }
    }

}
