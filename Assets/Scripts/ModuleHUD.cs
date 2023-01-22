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
    public bool Damaged;
    public bool inactive;
    public bool unstable;
    public bool detached;
    public bool wild;
    public GameObject fireMotion;
    public GameObject damagedSprite;
    public int reqType;
    public bool automatised;
    public GameObject automatisedSprite;
    public GameObject wildMotion;

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
        automatised = false;
        Damaged = false;
        unstable = false;
        detached = false;
        wild = false;
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

        if (automatised)
            automatisedSprite.gameObject.SetActive(true);
        else
            automatisedSprite.gameObject.SetActive(false);
        if (Damaged)
            damagedSprite.gameObject.SetActive(true);
        else
            damagedSprite.gameObject.SetActive(false);
        if (wild)
            wildMotion.gameObject.SetActive(true);
        else
            wildMotion.gameObject.SetActive(false);

        if (type == (ModuleType)0)
        {
            this.GetComponent<Image>().color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
        }
        if (type == (ModuleType)1)
        {
            this.GetComponent<Image>().color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
        }
        if (type == (ModuleType)2)
        {
            this.GetComponent<Image>().color = new Color(0.55f, 0.7254f, 0.8784f, 1);
        }
        if (type == (ModuleType)3)
        {
            this.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
        }
        if (type == (ModuleType)4)
        {
            this.GetComponent<Image>().color = new Color(0.99f, 0.84f, 0.4f, 1);
        }
        if (type == (ModuleType)5)
        {
            this.GetComponent<Image>().color = new Color(0.9843f, 1, 0.2196f, 1);
        }
        if (inactive)
            this.GetComponent<Image>().color = new Color32(45, 45, 45, 255);
    }

}