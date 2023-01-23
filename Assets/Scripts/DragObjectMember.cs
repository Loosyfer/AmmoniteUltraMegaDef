using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectMember : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Camera camera;
    private bool pointerDown;
    private bool rayCastNull;
    private bool objectDragged;
    public GameObjectHolder script;
    public GameObject malla;
    private Vector3 mousePositionOffset;
    public GameObject item;
    public GameObject showInfoButton;
    public GameObject slot;

    private void Awake()
    {
        objectDragged = false;
        pointerDown = false;
        rayCastNull = true;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        malla = GameObject.Find("/Malla");
        canvas = malla.GetComponent<Canvas>();
        camera = Camera.main;
        script = malla.transform.GetChild(15).GetComponent<GameObjectHolder>();
        showInfoButton = malla.transform.GetChild(15).GetChild(26).gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        objectDragged = true;
        if (slot != null)
        {
            slot.GetComponent<ItemSlot>().member = null;
            slot = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = GetMouseWorldPosition() + mousePositionOffset;
        if (item != null)
            item.transform.position = GetMouseWorldPosition() + mousePositionOffset + new Vector3(23, 15, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        GetComponent<Image>().raycastTarget = true;
        camera.GetComponent<CameraZoomController>().movingOn = false;
        StartCoroutine(WaitAfterClickUp());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        camera.GetComponent<CameraZoomController>().movingOn = true;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

    }

    void Update()
    {
        Debug.Log("pointerDown es " + pointerDown + " rayCastNull es " + rayCastNull + " objectDragged es " + objectDragged);
        if (Input.GetMouseButtonUp(0) && pointerDown && !objectDragged)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            if (script.activeModuleorMember != null)
            {
                if (script.activeModuleorMember.tag == "Module")
                    script.activeModuleorMember.GetComponent<ModuleHUD>().selected = false;
                if (script.activeModuleorMember.tag == "Member")
                    script.activeModuleorMember.GetComponent<MemberHUD>().selected = false;
                if (script.activeModuleorMember.tag == "Mega")
                    script.activeModuleorMember.GetComponent<MegaHUD>().selected = false;
                if (script.activeModuleorMember.tag == "Monster")
                {
                    script.activeModuleorMember.GetComponent<MonsterHUD>().selected = false;
                    script.activeModuleorMember.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                }
            }
            script.activeModuleorMember = EventSystem.current.currentSelectedGameObject;
            pointerDown = false;
            rayCastNull = true;
            script.activeModuleorMember.GetComponent<MemberHUD>().selected = true;
            camera.GetComponent<CameraZoomController>().movingOn = false;
        }
        if (Input.GetMouseButtonUp(0))
            pointerDown = false;
    }

    private bool GetRayCast()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "Member")
            {
                rayCastNull = false;
                return true;
            }
        }
        rayCastNull = true;
        return false;
    }

    IEnumerator WaitAfterClickUp()
    {
        yield return new WaitForSeconds(0.1f);
        objectDragged = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseOver()
    {
        if (showInfoButton.transform.GetComponent<ShowInfoButton>().showInfo)
        {
            this.transform.GetChild(4).gameObject.SetActive(true);
            if (this.transform.GetComponent<MemberHUD>().secTrait.text != "")
                this.transform.GetChild(23).gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        this.transform.GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(23).gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Checkpoint1");
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Checkpoint2");
            if (eventData.pointerDrag.transform.tag == "Item")
            {
                eventData.pointerDrag.transform.position = transform.position + new Vector3(23, 15, 0);
                item = eventData.pointerDrag.gameObject;
                eventData.pointerDrag.transform.GetComponent<DragObjectObject>().member = this.gameObject;
            }
        }
    }


}
