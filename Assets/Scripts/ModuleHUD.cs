using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModuleHUD : MonoBehaviour
{

    public Text nameText;
    public Text detailsText;
    public ModuleType type;
    public Text typeDetails;
    public Text req;
    public int price;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public Slider slider;
    public int sliderLength;
    public bool cooldownActive = false;
    public bool selected;
    public bool WFlooded;
    public bool SFlooded;
    public bool Freezed;
    public bool insideField;
    public bool onFire;
    public GameObject fireMotion;

    public void SetHUD(Module module)
    {
        nameText.text = module.unitName;
        detailsText.text = module.details;
        type = module.type;
        req.text = module.req;
        price = module.price;
        typeDetails.text = module.typeDetails;
        WFlooded = false;
        SFlooded = false;
        Freezed = false;
        insideField = false;
        onFire = false;
    }

    void Update()
    {
        if (selected)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //this.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (WFlooded)
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        else
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        if (SFlooded)
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
        else
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        if (onFire)
            fireMotion.SetActive(true);
        else
            fireMotion.SetActive(false);
    }

}