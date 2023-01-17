using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public Camera camera;
    public GameObject module;
    public GameObject member;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.transform.tag == "Member")
            {
                eventData.pointerDrag.transform.position = transform.position - new Vector3(0, 18.4f, 0);
                if (eventData.pointerDrag.transform.GetComponent<DragObjectMember>().item != null)
                    eventData.pointerDrag.transform.GetComponent<DragObjectMember>().item.transform.position = transform.position - new Vector3(0, 18.4f, 0) + new Vector3(23, 15, 0);
                member = eventData.pointerDrag.gameObject;
            }
            if (eventData.pointerDrag.transform.tag == "Module")
            {
                eventData.pointerDrag.transform.position = transform.position;
                module = eventData.pointerDrag.gameObject;
            }
            //GetComponent<RectTransform>().anchoredPosition
        }
    }

}
