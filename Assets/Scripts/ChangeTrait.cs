using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrait : MonoBehaviour
{

    public BattleSystem script;
    private int index;

    public void Change(string s)
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            if (int.TryParse(s, out int index))
            {
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().trait.text = script.memExcel.myMembers.members[index].trait;
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().traitDetailsText.text = script.memExcel.myMembers.members[index].tEffect;
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().id = index;
            }
        }
    }
}
