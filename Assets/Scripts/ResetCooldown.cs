using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCooldown : MonoBehaviour
{

    public void Reset()
    {
        ModuleHUD module = transform.GetComponent<ModuleHUD>();
        module.transform.GetChild(1).gameObject.GetComponent<Slider>().value = 1;
        module.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
    }

}
