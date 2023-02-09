using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class InputPerformance : MonoBehaviour
{
    private GameObject member;

    public void ChangePerformance(string s)
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            if (int.TryParse(s, out int number))
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
                member.GetComponent<MemberHUD>().performance += number;
            }

        }

    }

}
