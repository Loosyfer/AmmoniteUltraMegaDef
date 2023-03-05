using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOverExtend : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject infoPanels;
    public GameObject showInfoButton;
    public GameObject moduleParent;
    public GameObject malla;

    private void Start()
    {
        malla = GameObject.Find("/Malla");
        showInfoButton = malla.transform.GetChild(15).GetChild(26).gameObject;
    }

    public void OnMouseOver()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(130, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.0841f, 2.98f, 0);
        if (showInfoButton.transform.GetComponent<ShowInfoButton>().showInfo)
        {
            infoPanels.gameObject.SetActive(true);
            if (moduleParent.transform.GetComponent<ModuleHUD>().reqType == 2)
            {
                infoPanels.transform.GetChild(2).gameObject.SetActive(true);
                infoPanels.transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }

    public void OnMouseExit()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(62.5f, 11);
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(-0.0841f, 2.98f, 0);
        infoPanels.gameObject.SetActive(false);
    }
}
