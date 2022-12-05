using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrait : MonoBehaviour
{

    public MemInfo script;
    private int index;

    public void Change(string s)
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            if (int.TryParse(s, out int index))
            {
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().trait.text = script.traitList[index];
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().traitDetailsText.text = script.tDescription[index];
            }
        }
    }
}
