using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCDSwitch : MonoBehaviour
{

    private ModuleHUD module;

    public void Cooldown()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
        {
            Image image = transform.GetComponent<Image>();
            module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
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

    void Update()
    {
        Image image = transform.GetComponent<Image>();
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
        {
            module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember == null)
            {
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                if (module.sliderLength > 0)
                {
                    if (module.cooldownActive == false)
                        image.color = new Color(1, 0, 0, 1);
                    else
                        image.color = new Color(0, 1, 0, 1);
                }
                else
                    image.color = new Color(1, 1, 1, 1);
            }
        }
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember == null)
            image.color = new Color(1, 1, 1, 1);
    }
}




