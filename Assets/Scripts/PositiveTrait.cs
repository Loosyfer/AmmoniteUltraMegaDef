using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveTrait : MonoBehaviour
{

    private GameObject memberorModule;
    public PositiveTraits positiveTraits;

    public void SetPositiveTrait()
    {
        if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                int random = Random.Range(0, positiveTraits.names.Length);
                memberorModule = this.transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                MemberHUD memberHUD = memberorModule.GetComponent<MemberHUD>();
                memberHUD.secTrait.text = positiveTraits.names[random];
                memberHUD.secTraitDescription.text = positiveTraits.names[random] + " = " + positiveTraits.description[random];
            }
        }
    }
}
