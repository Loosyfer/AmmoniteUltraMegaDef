using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOver : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverPanel;
    public GameObject HoverPanel2;
    private GameObject showInfoButton;
    private GameObject malla;

    private void Start()
    {
        malla = GameObject.Find("/Malla");
        showInfoButton = malla.transform.GetChild(15).GetChild(26).gameObject;
    }


    public void OnMouseOver()
    {
        if (showInfoButton.transform.GetComponent<ShowInfoButton>().showInfo)
        {
            HoverPanel.SetActive(true);
            HoverPanel2.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        HoverPanel.SetActive(false);
        HoverPanel2.SetActive(false);
    }
}
