using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MegaHUD : MonoBehaviour
{

    //public Text nameText;
    public Text detailsText;
    public ModuleType type;
    public Text req;
    public Slider slider;
    public int sliderLength;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public bool cooldownActive = false;
    public bool selected;

    public void SetHUD(Mega mega)
    {
        //nameText.text = mega.unitName;
        detailsText.text = mega.details;
        type = mega.type;
        req.text = mega.req;
    }

    void Update()
    {
        /*if (selected)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }*/
    }

}