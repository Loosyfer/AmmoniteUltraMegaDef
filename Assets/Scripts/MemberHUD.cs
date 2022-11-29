using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemberHUD : MonoBehaviour
{

    public Text nameText;
    public Text profDetailsText;
    public Text traitDetailsText;
    public ProfessionType profession;
    public Text trait;
    public Text totalPrice;
    public Text profPrice;
    public Text traitPrice;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public float performance;

    public void SetHUD(Member member)
    {
        nameText.text = member.unitName;
        profDetailsText.text = member.professionDetails;
        traitDetailsText.text = member.traitDetails;
        profession = member.unitProfession;
        trait.text = member.trait;
        totalPrice.text = member.totalPrice.ToString();
        profPrice.text = member.profPrice.ToString();
        traitPrice.text = member.traitPrice.ToString();
        performance = member.performance;

    }

    public void ReadStringInput(string s)
    {
        performance = float.Parse(s);
    }

}