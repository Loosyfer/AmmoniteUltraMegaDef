using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectModule : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
        //GetComponent<Image>().raycastTarget = true;
        camera.GetComponent<CameraZoomController>().movingOn = false;
        StartCoroutine(WaitAfterClickUp());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GetRaycast())
        {
            Debug.Log("Todo funciona a pedir de Milhouse");
            GetComponent<Image>().raycastTarget = false;
        }
        else
            pointerDown = true;
        camera.GetComponent<CameraZoomController>().movingOn = true;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

    }

    void Update()
    {

        if (GetRaycast())
            GetComponent<Image>().raycastTarget = false;
        else
            GetComponent<Image>().raycastTarget = true;

        Debug.Log("GetRayCast es " + GetRaycast());

        if (Input.GetMouseButtonDown(0) && GetRaycast())
        {
            GetComponent<Image>().raycastTarget = false;
        }

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
            script.activeModuleorMember.GetComponent<ModuleHUD>().selected = true;
            camera.GetComponent<CameraZoomController>().movingOn = false;
        }

        if (Input.GetMouseButtonUp(0))
            GetComponent<Image>().raycastTarget = true;
            
    }

    private bool GetRaycast()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "Member")
            {
                EventSystem.current.SetSelectedGameObject(hits[i].transform.gameObject);
                return true;
            }
        }
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
}
