using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTrait : MonoBehaviour
{

    public BattleSystem script;
    private GameObject memberorModule;
    public MemberExcel memExcel;
    private List<MemberExcel.Member> superTraits = new List<MemberExcel.Member>();
    private List<int> indexes = new List<int>();

    private void Awake()
    {

    }

    public void SetSuperTrait()
    {
        for (int j = 0; j < script.memExcel.myMembers.members.Length; j++)
        {
            if (script.memExcel.myMembers.members[j].super)
            {
                superTraits.Add(script.memExcel.myMembers.members[j]);
                indexes.Add(j);
            }
        }

        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(0, superTraits.Count);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = superTraits[random].trait;
                memberHUD.secTraitDescription.text = superTraits[random].trait + " = " + superTraits[random].tEffect;
                memberHUD.secTraitDescription.text = memberHUD.secTraitDescription.text.Replace("*", ",");
                memberHUD.id2 = indexes[random];
                memberHUD.id2Active = true;
            }
        }
    }
}
