using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSecondTrait : MonoBehaviour
{
    private GameObject memberorModule;
    public BattleSystem script;

    public void AddTrait(string s)
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = script.memExcel.myMembers.members[int.Parse(s)].trait;
                memberHUD.secTraitDescription.text = script.memExcel.myMembers.members[int.Parse(s)].tEffect;
                memberHUD.secTraitDescription.text = memberHUD.secTraitDescription.text.Replace("*", ",");
                memberHUD.id2 = int.Parse(s);
                memberHUD.id2Active = true;
                // membersInfo.traitList[int.Parse(s)] + " = " + 
            }
        }
    }
}
