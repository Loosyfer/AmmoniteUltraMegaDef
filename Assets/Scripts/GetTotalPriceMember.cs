using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTotalPriceMember : MonoBehaviour
{
    private string traitPrice;
    private string profPrice;

    public GameObject holder;
    public Text text;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holder.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                traitPrice = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().traitPrice.text;
                profPrice = holder.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profPrice.text;
                int sum1;
                int sum2;
                int sum;
                int.TryParse(traitPrice, out sum1);
                int.TryParse(profPrice, out sum2);
                sum = sum1 + sum2;
                text.text = "Trait Price (" + sum1 + ") + Prof Price (" + sum2 + ") = " + sum;
            }
            if (holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module" || holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega" || holder.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Mega2")
                text.text = "";
        }
    }
}
