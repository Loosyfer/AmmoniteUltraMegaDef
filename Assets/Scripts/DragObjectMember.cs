using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectMember : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private MovingObject mO;
    public Camera camera;
    private bool pointerDown;
    private bool rayCastNull;
    private bool objectDragged;
    public GameObjectHolder script;

    private void Awake()
    {
        objectDragged = false;
        pointerDown = false;
        rayCastNull = true;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        GameObject canvasObject = GameObject.Find("/Malla");
        canvas = canvasObject.GetComponent<Canvas>();
        GameObject cameraObject = GameObject.Find("/Main Camera");
        camera = cameraObject.GetComponent<Camera>();
        script = GameObject.Find("/Malla/ButtonPanel").GetComponent<GameObjectHolder>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        objectDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = false;
        GetComponent<Image>().raycastTarget = true;
        StartCoroutine(WaitAfterClickUp());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit hit = isPointerOverMember();
        if (!rayCastNull)
        {
            pointerDown = true;
        }
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = true;

    }

    void Update()
    {
        Debug.Log("PointerDown is " + pointerDown);
        Debug.Log("rayCastNull is " + rayCastNull);
        Debug.Log("objectDragged is " + objectDragged);
        if (Input.GetMouseButtonUp(0) && pointerDown && !rayCastNull && !objectDragged)
        {
            Debug.Log("AQUIIIIIIIIIIIIIIIIII");
            EventSystem.current.SetSelectedGameObject(gameObject);
            if (script.activeModuleorMember != null && script.activeModuleorMember.tag == "Module")
                script.activeModuleorMember.GetComponent<ModuleHUD>().selected = false;
            if (script.activeModuleorMember != null && script.activeModuleorMember.tag == "Member")
                script.activeModuleorMember.GetComponent<MemberHUD>().selected = false;
            script.activeModuleorMember = EventSystem.current.currentSelectedGameObject;
            pointerDown = false;
            rayCastNull = true;
            script.activeModuleorMember.GetComponent<MemberHUD>().selected = true;
            mO = canvas.GetComponent<MovingObject>();
            mO.movingOn = false;
        }
    }

    private RaycastHit isPointerOverMember()
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

}
