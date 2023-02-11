using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EruditeTrait : MonoBehaviour
{

    public BattleSystem script;
    private GameObject memberorModule;
    public MemberExcel memExcel;
    private List<MemberExcel.Member> eruditeTraits = new List<MemberExcel.Member>();

    private void Awake()
    {
        for (int j = 0; j < script.memExcel.myMembers.members.Length; j++)
        {
            if (script.memExcel.myMembers.members[j].erudite)
            {
                eruditeTraits.Add(script.memExcel.myMembers.members[j]);
            }
        }
    }

    public void SetEruditeTrait()
    {
        for (int j = 0; j < script.memExcel.myMembers.members.Length; j++)
        {
            if (script.memExcel.myMembers.members[j].erudite)
            {
                eruditeTraits.Add(script.memExcel.myMembers.members[j]);
            }
        }

        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(0, eruditeTraits.Count);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = eruditeTraits[random].trait;
                memberHUD.secTraitDescription.text = eruditeTraits[random].trait + " = " + eruditeTraits[random].tEffect;
            }
        }
    }
}
