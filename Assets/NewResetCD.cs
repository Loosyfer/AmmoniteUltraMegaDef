using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewResetCD : MonoBehaviour
{
    private ModuleHUD module;

    public void Reset()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
        {
            module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
            module.transform.GetChild(1).gameObject.GetComponent<Slider>().value = module.transform.GetChild(1).gameObject.GetComponent<Slider>().maxValue;
            module.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
        }

    }

}
