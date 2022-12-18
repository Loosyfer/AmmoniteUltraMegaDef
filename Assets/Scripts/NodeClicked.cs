using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeClicked : MonoBehaviour,  IDropHandler
{
    private bool clicked = false;
    [SerializeField]
    private Camera camera;

    public void Click()
    {
        
        if (clicked)
        {
            clicked = false;
            this.transform.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
        else
        {
            clicked = true;
            this.transform.GetComponent<Image>().color = new Color32(79, 236, 88, 255);
        }
    }

    private void Update()
    {
        Debug.Log("Is over button is " + IsOverButton());
        if (Input.GetMouseButtonDown(1) && IsOverButton())
        {
            Click();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = transform.position;
            //GetComponent<RectTransform>().anchoredPosition
        }
    }

    private bool IsOverButton()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if ((hits[i].transform == this.transform))
                return true;
        }
        return false;
    }
}
