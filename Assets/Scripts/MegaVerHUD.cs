using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MegaVerHUD : MonoBehaviour
{

    public Text nameText;
    public Text detailsText;
    public ModuleType type;
    public Text req;
    public Text typeDetails;
    public Slider slider;
    public int sliderLength;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public bool cooldownActive = false;
    public bool selected;
    public bool WFlooded;
    public bool SFlooded;
    public bool Freezed;
    public bool onFire;
    public bool Damaged;
    public bool inactive;
    public bool unstable;
    public bool detached;
    public bool wild;
    public GameObject fireMotion;
    public GameObject damagedSprite1;
    public GameObject damagedSprite2;
    public GameObject wildMotion1;
    public GameObject wildMotion2;
    public GameObject module;

    public void SetHUD(Mega mega)
    {
        nameText.text = mega.unitName;
        detailsText.text = mega.details;
        type = mega.type;
        req.text = mega.req;
        typeDetails.text = mega.typeDetails;
        WFlooded = false;
        SFlooded = false;
        Freezed = false;
        onFire = false;
        Damaged = false;
        inactive = false;
        unstable = false;
        detached = false;
        wild = false;
    }

    void Update()
    {
        if (selected)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        else
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

        if (WFlooded)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
        if (SFlooded)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
        if (onFire)
        {
            fireMotion.SetActive(true);
        }
        else
            fireMotion.SetActive(false);
        if (Damaged)
        {
            damagedSprite1.SetActive(true);
            damagedSprite2.SetActive(true);
        }
        else
        {
            damagedSprite1.SetActive(false);
            damagedSprite2.SetActive(false);
        }
        if (inactive)
            module.GetComponent<SpriteRenderer>().color = new Color32(45, 45, 45, 255);
        else
            module.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        if (wild)
        {
            wildMotion1.SetActive(true);
            wildMotion2.SetActive(true);
        }
        else
        {
            wildMotion1.SetActive(false);
            wildMotion2.SetActive(false);
        }

    }

}