using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTraitToPanel : MonoBehaviour
{

    public GameObject holder;
    public Text text;

    void Update()
    {
        if (holder.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().traitDetailsText.text;
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<ModuleHUD>().detailsText.text;
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaHUD>().detailsText.text;
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega2")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MegaVerHUD>().detailsText.text;
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Monster")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MonsterHUD>().instructions;
        }
    }
}
