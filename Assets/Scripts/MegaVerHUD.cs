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
    public GameObject fireMotion;

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
    }

}