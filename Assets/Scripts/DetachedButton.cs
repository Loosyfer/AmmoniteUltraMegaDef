using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedButton : MonoBehaviour
{
    private ModuleHUD module;
    private MegaHUD mega;
    private MegaVerHUD mega2;
    private string tag;

    public void Detached()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega" || tag == "Mega2"))
        {

            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
                if (module.detached == true)
                {
                    module.detached = false;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    module.detached = true;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Module_Detached");
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.detached == true)
                {
                    mega.detached = false;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega.detached = true;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Module_Detached_Mega");
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega2")
            {
                mega2 = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>();
                if (mega2.detached == true)
                {
                    mega2.detached = false;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega2.detached = true;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Module_Detached_Mega");
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    void Update()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember == null)
            transform.GetChild(1).gameObject.SetActive(false);
        else
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
                transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
