using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectMega : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool pointerDown;
    private bool rayCastNull;
    private bool objectDragged;
    public GameObjectHolder script;
    public GameObject malla;
    private Vector3 mousePositionOffset;
    public GameObject showInfoButton;
    public GameObject infoPanels;

    public Camera camera;

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

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        //GetComponent<SpriteRenderer>().raycastTarget = true;
        camera.GetComponent<CameraZoomController>().movingOn = false;
        StartCoroutine(WaitAfterClickUp());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit hit = isPointerOverModule();
        if (!rayCastNull)
        {
            if (hit.collider.gameObject.tag == "Member")
            {
                //GetComponent<SpriteRenderer>().raycastTarget = false;
            }
            else
            {
                pointerDown = true;
            }
        }
        camera.GetComponent<CameraZoomController>().movingOn = true;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && pointerDown && !rayCastNull && !objectDragged)
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
                if (script.activeModuleorMember.tag == "Mega2")
                    script.activeModuleorMember.GetComponent<MegaVerHUD>().selected = false;
                if (script.activeModuleorMember.tag == "Monster")
                {
                    script.activeModuleorMember.GetComponent<MonsterHUD>().selected = false;
                    script.activeModuleorMember.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                }
            }
            
            script.activeModuleorMember = EventSystem.current.currentSelectedGameObject;
            pointerDown = false;
            rayCastNull = true;
            if (script.activeModuleorMember.tag == "Mega")
                script.activeModuleorMember.GetComponent<MegaHUD>().selected = true;
            if (script.activeModuleorMember.tag == "Mega2")
                script.activeModuleorMember.GetComponent<MegaVerHUD>().selected = true;
            camera.GetComponent<CameraZoomController>().movingOn = false;
        }

    }

    private RaycastHit isPointerOverModule()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            rayCastNull = false;
        else
            rayCastNull = true;
        return hit;
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
            infoPanels.gameObject.SetActive(true);
            if (this.gameObject.tag == "Mega")
            {
                if (this.transform.GetComponent<MegaHUD>().req.text != "No Requirement") ;
                {
                    infoPanels.transform.GetChild(1).gameObject.SetActive(true);
                    infoPanels.transform.GetChild(3).gameObject.SetActive(true);
                }
            }
            else
            {
                if (this.transform.GetComponent<MegaVerHUD>().req.text != "No Requirement") ;
                {
                    infoPanels.transform.GetChild(1).gameObject.SetActive(true);
                    infoPanels.transform.GetChild(3).gameObject.SetActive(true);
                }

            }
        }
    }

    private void OnMouseExit()
    {
        infoPanels.gameObject.SetActive(false);

    }
}
