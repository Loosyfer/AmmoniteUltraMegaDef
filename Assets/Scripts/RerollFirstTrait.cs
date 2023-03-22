using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollFirstTrait : MonoBehaviour
{
    private GameObject memberorModule;
    public BattleSystem script;
    private System.Random randomTrait = new System.Random();

    public void Reroll()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = randomTrait.Next(0, 210);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.trait.text = script.memExcel.myMembers.members[random].trait;
                memberHUD.traitDetailsText.text = script.memExcel.myMembers.members[random].trait + " = " + script.memExcel.myMembers.members[random].tEffect;
                memberHUD.traitDetailsText.text = memberHUD.traitDetailsText.text.Replace("*", ",");
                memberHUD.id = random;
            }
        }
    }
}
