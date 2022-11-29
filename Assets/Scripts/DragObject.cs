using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private MovingObject mO;
    public Camera camera;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        GameObject canvasObject = GameObject.Find("/Malla");
        canvas = canvasObject.GetComponent<Canvas>();
        GameObject cameraObject = GameObject.Find("/Main Camera");
        camera = cameraObject.GetComponent<Camera>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform.anchoredPosition += eventData.delta*1000 / (canvas.scaleFactor * camera.orthographicSize);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = true;
    }

}
