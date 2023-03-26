using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjectIcon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Camera camera;
    private bool pointerDown;
    private bool rayCastNull;
    private bool objectDragged;
    private Vector3 mousePositionOffset;
    [SerializeField]
    private GameObject iconPrefab;
    private bool firstDragged;

    private void Awake()
    {
        objectDragged = false;
        pointerDown = false;
        rayCastNull = true;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        firstDragged = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        objectDragged = true;
        if (!firstDragged)
        {
            CreateNewIcon(this.GetComponent<Image>().sprite, this.rectTransform.position, canvas, camera, iconPrefab);
            this.transform.parent.GetComponent<IconsFolder>().icons.Add(this.gameObject);
            firstDragged = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        GetComponent<Image>().raycastTarget = true;
        camera.GetComponent<CameraZoomControllerTwo>().movingOn = false;
        StartCoroutine(WaitAfterClickUp());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        camera.GetComponent<CameraZoomControllerTwo>().movingOn = true;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();

    }

    void Update()
    {

        if ((Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) && pointerDown && !objectDragged)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            pointerDown = false;
            camera.GetComponent<CameraZoomControllerTwo>().movingOn = false;
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

    private Vector3 GetMouseWorldPosition()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool MouseIsOverIcon()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        for (int i = 0; i < hits.Length; i++)
        {
            if ((hits[i].transform.tag == "Icon"))
            {
                return true;
            }
        }
        return false;
    }

    private void CreateNewIcon(Sprite sprite, Vector3 position, Canvas canvass, Camera cameraa, GameObject iconPrefabb)
    {
        GameObject go = Instantiate(iconPrefab, position, Quaternion.identity) as GameObject;
        go.GetComponent<Image>().sprite = sprite;
        go.GetComponent<DragObjectIcon>().canvas = canvass;
        go.GetComponent<DragObjectIcon>().camera = cameraa;
        go.GetComponent<DragObjectIcon>().iconPrefab = iconPrefabb;
        go.transform.parent = GameObject.Find("Canvas").transform.GetChild(8);
    }

}
