using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownSwitch : MonoBehaviour
{

    public void Cooldown()
    {
        ModuleHUD module = transform.GetComponent<ModuleHUD>();
        Image image = transform.GetChild(0).GetComponent<Image>();
        if (module.cooldownActive == true)
        {
            module.cooldownActive = false;
            image.color = new Color(1, 0, 0, 1);
        }
        else
        {
            module.cooldownActive = true;
            image.color = new Color(0, 1, 0, 1);
        }
    }

}
