using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberDecreaseHP : MonoBehaviour
{

    public GameObject holder;
    private GameObject member;

    public void DecreaseHP(string s)
    {
        if (holder.GetComponent<GameObjectHolder>().activeModuleorMember != null)
            member = holder.GetComponent<GameObjectHolder>().activeModuleorMember;

        if (member.tag == "Member")
        {
            member.transform.GetComponent<MemberHUD>().health = int.Parse(s);
        }

    }
}
