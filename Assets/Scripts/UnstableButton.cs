using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableButton : MonoBehaviour
{
    private ModuleHUD module;
    private MegaHUD mega;
    private MegaVerHUD mega2;
    private string tag;

    public void Unstable()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega" || tag == "Mega2"))
        {

            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
                if (module.unstable == true)
                {
                    module.unstable = false;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    module.unstable = true;
                    transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Module_Unstable");
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.unstable == true)
                {
                    mega.unstable = false;
                    if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.childCount == 20)
                        transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(13).GetComponent<Animator>().Play("Nothing");
                    else
                        transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(12).GetComponent<Animator>().Play("Nothing");
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega.unstable = true;
                    if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.childCount == 20)
                        transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(13).GetComponent<Animator>().Play("Module_Unstable");
                    else
                        transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(12).GetComponent<Animator>().Play("Module_Unstable");
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            if (tag == "Mega2")
            {
                mega2 = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>();
                if (mega2.onFire == true)
                {
                    mega2.onFire = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    mega2.onFire = true;
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
