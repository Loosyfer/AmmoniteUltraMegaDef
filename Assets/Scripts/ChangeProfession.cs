using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProfession : MonoBehaviour
{

    public MemInfo script;
    private int index;

    public void Change(string s)
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            if (int.TryParse(s, out int index))
            { 
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profession = (ProfessionType)index;
            transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profDetailsText.text = script.profDescription[index];
            transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(2).GetComponent<GetProfession>().UpdateProf();
            }
        }
    }
}
