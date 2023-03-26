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
    public GameObject shipField;
    public GameObject infoPanels;
    public GameObject showInfoButton;
    public GameObject slot;
    public Camera camera;
    public bool beingDrag;
    public BattleSystem bS;

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
        bS = GameObject.Find("/Battle System").GetComponent<BattleSystem>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        objectDragged = true;
        if (slot != null)
        {
            slot.GetComponent<ItemSlot>().module = null;
            slot = null;
        }
        infoPanels.gameObject.SetActive(false);
        beingDrag = true;
        GlobalVariables.objectBeingDragged = true;
        transform.SetSiblingIndex(0);
        foreach (GameObject module in bS.modules)
        {
            if (module != this.gameObject)
            {
                module.transform.GetComponent<Canvas>().sortingOrder = 0;
                module.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(4).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(5).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(6).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(7).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(8).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(9).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(10).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(11).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(12).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(10).transform.GetChild(13).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(19).GetComponent<SpriteRenderer>().sortingOrder = 1;
                module.transform.GetChild(20).GetComponent<Canvas>().sortingOrder = 1;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = GetMouseWorldPosition() + mousePositionOffset;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -2);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        //GetComponent<Image>().raycastTarget = true;
        camera.GetComponent<CameraZoomController>().movingOn = false;
        StartCoroutine(WaitAfterClickUp());
        infoPanels.gameObject.SetActive(true);
        beingDrag = false;
        GlobalVariables.objectBeingDragged = false;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        foreach (GameObject module in bS.modules)
        {
            if (module != this.gameObject)
            {
                module.transform.GetComponent<Canvas>().sortingOrder = 1;
                module.transform.GetChild(1).GetComponent<Canvas>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(4).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(5).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(6).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(7).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(8).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(9).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(10).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(11).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(12).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(10).transform.GetChild(13).GetComponent<SpriteRenderer>().sortingOrder = 3;
                module.transform.GetChild(19).GetComponent<SpriteRenderer>().sortingOrder = 4;
                module.transform.GetChild(20).GetComponent<Canvas>().sortingOrder = 5;
            }
        }

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
        script.activeModuleorMember.GetComponent<ModuleHUD>().selected = true;

    }

    void Update()
    {

        if (GetRaycast())
            GetComponent<Image>().raycastTarget = false;
        else
            GetComponent<Image>().raycastTarget = true;


        if (Input.GetMouseButtonDown(0) && GetRaycast())
        {
            GetComponent<Image>().raycastTarget = false;
        }

        if (Input.GetMouseButtonUp(0) && pointerDown && !objectDragged)
        {
            /*EventSystem.current.SetSelectedGameObject(gameObject);
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
            script.activeModuleorMember = EventSystem.current.currentSelectedGameObject;*/
            pointerDown = false;
            rayCastNull = true;
            //script.activeModuleorMember.GetComponent<ModuleHUD>().selected = true;
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

    private void OnMouseOver()
    {
        if (showInfoButton.transform.GetComponent<ShowInfoButton>().showInfo)
        {
            if (!beingDrag && !GlobalVariables.objectBeingDragged)
            {
                infoPanels.gameObject.SetActive(true);
                if (this.transform.GetComponent<ModuleHUD>().reqType == 2)
                {
                    infoPanels.transform.GetChild(2).gameObject.SetActive(true);
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
