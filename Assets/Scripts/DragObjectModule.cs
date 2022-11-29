using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectModule : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    public Vector3 collision = Vector3.zero;
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
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = false;
        GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
   
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))

            Debug.Log("Todo funciona");
            if (hit.collider.gameObject.tag == "Member")
            {
                Debug.Log("And Yet Another Prueba");
                GetComponent<Image>().raycastTarget = false;
            }
        mO = canvas.GetComponent<MovingObject>();
        mO.movingOn = true;

    }

}
