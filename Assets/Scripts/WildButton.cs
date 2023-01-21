using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildButton : MonoBehaviour
{
    private ModuleHUD module;
    private MegaHUD mega;
    private MegaVerHUD mega2;
    private string tag;

    public void Wild()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega" || tag == "Mega2"))
        {

            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
                if (module.wild == true)
                {
                    module.wild = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    module.wild = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.wild == true)
                {
                    mega.wild = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega.wild = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega2")
            {
                mega2 = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>();
                if (mega2.wild == true)
                {
                    mega2.wild = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega2.wild = true;
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
