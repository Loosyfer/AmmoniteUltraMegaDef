using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    private ModuleHUD module;
    private MegaHUD mega;
    private MegaVerHUD mega2;
    private string tag;

    public void DamagedModule()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega" || tag == "Mega2"))
        {

            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
                if (module.Damaged == true)
                {
                    module.Damaged = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    module.Damaged = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.Damaged == true)
                {
                    mega.Damaged = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega.Damaged = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega2")
            {
                mega2 = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>();
                if (mega2.Damaged == true)
                {
                    mega2.Damaged = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega2.Damaged = true;
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
