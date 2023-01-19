using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedModules : MonoBehaviour
{

    private GameObject memberorModule;

    public void Automatised()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
            {
                this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().automatised = !this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().automatised;
            }
        }
    }
}
