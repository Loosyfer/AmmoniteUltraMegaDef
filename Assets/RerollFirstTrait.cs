using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollFirstTrait : MonoBehaviour
{
    private GameObject memberorModule;
    public MemInfo membersInfo;

    public void Reroll()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(0, 230);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.trait.text = membersInfo.traitList[random];
                memberHUD.traitDetailsText.text = membersInfo.traitList[random] + " = " + membersInfo.tDescription[random];
            }
        }
    }
}
