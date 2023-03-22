using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnergy : MonoBehaviour
{
    private int energyIndex = 0;

    public void EnergyChange()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.CompareTag("Module"))
        {
            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(22).transform.GetChild(energyIndex).gameObject.SetActive(true);
            for (int i = 0; i < 20; i++)
            {
                if (i != energyIndex)
                    this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(22).transform.GetChild(i).gameObject.SetActive(false);
            }
            if (energyIndex == 19)
                energyIndex = 0;
            else
                energyIndex++;
            this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().energy = energyIndex;
        }
    }
}
