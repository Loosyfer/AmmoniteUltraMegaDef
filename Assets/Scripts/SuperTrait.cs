using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTrait : MonoBehaviour
{

    private GameObject memberorModule;
    public SpecialTraits specialTraits;

    public void SetSuperTrait()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(15, 33);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = specialTraits.names[random];
                memberHUD.secTraitDescription.text = specialTraits.names[random] + " = " + specialTraits.description[random];
            }
        }
    }
}
