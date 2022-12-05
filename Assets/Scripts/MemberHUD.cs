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
    public bool selected;

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

    void Update()
    {
        if (selected)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(4).position = new Vector3(1700, 750, -2);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
        }
    }


}