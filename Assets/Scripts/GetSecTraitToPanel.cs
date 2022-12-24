using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSecTraitToPanel : MonoBehaviour
{

    public GameObject holder;
    public Text text;

    void Update()
    {
        if (holder.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
                text.text = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().secTraitDescription.text;
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
                text.text = "";
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega")
                text.text = "";
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega2")
                text.text = "";
        }
    }
}
