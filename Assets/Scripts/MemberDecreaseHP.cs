using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            member.transform.GetComponent<MemberHUD>().health += int.Parse(s);

            switch (member.transform.GetComponent<MemberHUD>().health)
            {
                case 4:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(0, 241, 81, 255);
                    return;
                case 3:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(226, 238, 11, 255);
                    return;
                case 2:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(244, 168, 26, 255);
                    return;
                case 1:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(254, 69, 7, 255);
                    return;
                case 0:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
                    return;
                default:
                    member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(17, 205, 238, 255);
                    return;
            }
        }

        

    }
}
