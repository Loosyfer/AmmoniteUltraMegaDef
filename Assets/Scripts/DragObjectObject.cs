using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragObjectObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
    public GameObject member;
    public bool beingDrag;
    public Camera camera;
    public GameObject hoverPanel1;
    public GameObject hoverPanel2;

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
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = false;
        objectDragged = true;
        if (member != null)
        {
            member.transform.GetComponent<DragObjectMember>().item = null;
        }
        this.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(55f, 55f);
        this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(335, 190);
        beingDrag = true;
        hoverPanel1.SetActive(false);
        hoverPanel2.SetActive(false);
        GlobalVariables.objectBeingDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = GetMouseWorldPosition() + mousePositionOffset;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        camera.GetComponent<CameraZoomController>().movingOn = false;
        beingDrag = false;
        hoverPanel1.SetActive(true);
        hoverPanel2.SetActive(true);
        GlobalVariables.objectBeingDragged = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        camera.GetComponent<CameraZoomController>().movingOn = true;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void Update()
    {

    }

    private Vector3 GetMouseWorldPosition()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }

}
