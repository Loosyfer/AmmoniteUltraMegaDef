using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSecondTrait : MonoBehaviour
{
    private GameObject memberorModule;
    public MemInfo membersInfo;

    public void AddTrait(string s)
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = membersInfo.traitList[int.Parse(s)];
                memberHUD.secTraitDescription.text = membersInfo.tDescription[int.Parse(s)];
                // membersInfo.traitList[int.Parse(s)] + " = " + 
            }
        }
    }
}
