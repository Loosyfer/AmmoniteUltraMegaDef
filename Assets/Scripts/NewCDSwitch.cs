using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCDSwitch : MonoBehaviour
{

    private ModuleHUD module;
    private MegaHUD mega;
    private string tag;

    public void Cooldown()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega"))
        {
            Image image = transform.GetComponent<Image>();
            if (tag == "Module")
            {
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
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.cooldownActive == true)
                {
                    mega.cooldownActive = false;
                    image.color = new Color(1, 0, 0, 1);
                }
                else
                {
                    mega.cooldownActive = true;
                    image.color = new Color(0, 1, 0, 1);
                }
            }
        }

    }

    void Update()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
            Image image = transform.GetComponent<Image>();
            if (tag == "Module")
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
            if (tag == "Mega")
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
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
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.sliderLength > 0)
                {
                    if (mega.cooldownActive == false)
                        image.color = new Color(1, 0, 0, 1);
                    else
                        image.color = new Color(0, 1, 0, 1);
                }
                else
                    image.color = new Color(1, 1, 1, 1);
            }
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember == null || transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
                image.color = new Color(1, 1, 1, 1);
        }
    }
}




