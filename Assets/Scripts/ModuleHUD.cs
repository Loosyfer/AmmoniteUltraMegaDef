using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModuleHUD : MonoBehaviour
{

    public Text nameText;
    public Text detailsText;
    public ModuleType type;
    public ModuleRequirements req;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public Slider slider;
    public int sliderLength;
    public bool cooldownActive = false;

    public void SetHUD(Module module)
    {
        nameText.text = module.unitName;
        detailsText.text = module.details;
        type = module.type;
        req = module.req;
    }

}