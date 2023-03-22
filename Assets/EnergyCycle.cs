using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCycle : MonoBehaviour
{

    public void EnergyChange()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.CompareTag("Module"))
        {
            switch (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy)
            {
                case int n when (n >= 0 && n <= 3):
                    if (n != 3)
                        this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy++;
                    else
                        this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 0;
                    break;
                case int n when (n == 4 || n == 5):
                    if (n == 4)
                        this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy++;
                    else
                        this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 4;
                    break;
                case int n when (n >= 6 && n <= 9):
                    switch (n)
                    {
                        case 6:
                            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 9;
                            break;
                        case 9:
                            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 7;
                            break;
                        case 7:
                            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 8;
                            break;
                        case 8:
                            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = 6;
                            break;
                    }
                    break;
            }
            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(22).transform.GetChild(this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy).gameObject.SetActive(true);
            for (int i = 0; i < 20; i++)
            {
                if (i != this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy)
                    this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(22).transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
