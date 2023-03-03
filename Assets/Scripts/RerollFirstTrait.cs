using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollFirstTrait : MonoBehaviour
{
    private GameObject memberorModule;
    public BattleSystem script;

    public void Reroll()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(0, 266);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.trait.text = script.memExcel.myMembers.members[random].trait;
                memberHUD.traitDetailsText.text = script.memExcel.myMembers.members[random].trait + " = " + script.memExcel.myMembers.members[random].tEffect;
                memberHUD.id = random;
            }
        }
    }
}
