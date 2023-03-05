using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Freezed : MonoBehaviour
{

    private ModuleHUD module;
    private MegaHUD mega;
    private MegaVerHUD mega2;
    private string tag;

    public void ModuleFreezed()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            tag = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag;
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && (tag == "Module" || tag == "Mega" || tag == "Mega2"))
        {

            if (tag == "Module")
            {
                module = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>();
                if (module.Freezed == true)
                {
                    module.Freezed = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                    StartCoroutine(DeFreezed3(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember));
                }

                else
                {
                    module.Freezed = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                    Freeze3(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember);
                }
            }
            if (tag == "Mega")
            {
                mega = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>();
                if (mega.Freezed == true)
                {
                    mega.Freezed = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                    StartCoroutine(DeFreezed1(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember));
                }
                else
                {
                    mega.Freezed = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                    Freeze1(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember);
                }
            }
            if (tag == "Mega2")
            {
                mega2 = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>();
                if (mega2.Freezed == true)
                {
                    mega2.Freezed = false;
                    transform.GetChild(1).gameObject.SetActive(false);
                    StartCoroutine(DeFreezed2(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember));
                }
                else
                {
                    mega2.Freezed = true;
                    transform.GetChild(1).gameObject.SetActive(true);
                    Freeze2(transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember);
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

    IEnumerator DeFreezed1(GameObject ob)
    {
        ob.transform.GetChild(10).gameObject.SetActive(true);
        ob.transform.GetChild(11).gameObject.SetActive(true);
        ob.transform.GetChild(8).gameObject.SetActive(false);
        ob.transform.GetChild(9).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        ob.transform.GetChild(10).gameObject.SetActive(false);
        ob.transform.GetChild(11).gameObject.SetActive(false);
    }

    private void Freeze1(GameObject ob)
    {
        ob.transform.GetChild(8).gameObject.SetActive(true);
        ob.transform.GetChild(9).gameObject.SetActive(true);
    }

    IEnumerator DeFreezed2(GameObject ob)
    {
        ob.transform.GetChild(8).gameObject.SetActive(true);
        ob.transform.GetChild(9).gameObject.SetActive(true);
        ob.transform.GetChild(6).gameObject.SetActive(false);
        ob.transform.GetChild(7).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        ob.transform.GetChild(8).gameObject.SetActive(false);
        ob.transform.GetChild(9).gameObject.SetActive(false);
    }

    private void Freeze2(GameObject ob)
    {
        ob.transform.GetChild(6).gameObject.SetActive(true);
        ob.transform.GetChild(7).gameObject.SetActive(true);
    }

    IEnumerator DeFreezed3(GameObject ob)
    {
        ob.transform.GetChild(7).gameObject.SetActive(true);
        ob.transform.GetChild(6).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        ob.transform.GetChild(7).gameObject.SetActive(false);
    }

    private void Freeze3(GameObject ob)
    {
        ob.transform.GetChild(6).gameObject.SetActive(true);
    }
}
