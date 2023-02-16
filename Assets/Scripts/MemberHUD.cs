using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MemberHUD : MonoBehaviour
{

    public Text nameText;
    public Text profDetailsText;
    public TMP_Text traitDetailsText;
    public ProfessionType profession;
    public Text trait;
    public Text secTrait;
    public Text secTraitDescription;
    public Text totalPrice;
    public Text profPrice;
    public Text traitPrice;
    public Color Colours = new Color(1f, 1f, 1f, 1f);
    public float performance;
    public bool selected;
    public int health;
    public bool insideField = false;
    public int id;
    public int id2;
    public bool id2Active;
    public int professionId;

    public void SetHUD(Member member)
    {
        nameText.text = member.unitName;
        profDetailsText.text = member.professionDetails;
        traitDetailsText.text = member.traitDetails;
        profession = member.unitProfession;
        trait.text = member.trait;
        secTrait.text = member.secTrait;
        secTraitDescription.text = member.secTraitDescription;
        totalPrice.text = member.totalPrice.ToString();
        profPrice.text = member.profPrice.ToString();
        traitPrice.text = member.traitPrice.ToString();
        performance = member.performance;
        health = member.health;
        id2Active = false;

    }

    private void Awake()
    {
        health = 6;
    }

    void Update()
    {

        this.transform.GetChild(22).GetComponent<TextMeshProUGUI>().text = health.ToString();

        if (selected)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //this.transform.GetChild(4).gameObject.SetActive(true);
            //this.transform.GetChild(4).position = new Vector3(17, 17, -2);
            //this.transform.GetChild(20).gameObject.SetActive(true);
            //this.transform.GetChild(20).position = new Vector3(17, 5, -2);
            //this.transform.GetChild(5).gameObject.SetActive(true);
           //this.transform.GetChild(5).position = new Vector3(335, 0, -2);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //this.transform.GetChild(4).gameObject.SetActive(false);
            //this.transform.GetChild(21).gameObject.SetActive(false);
            //this.transform.GetChild(5).gameObject.SetActive(false);
        }
    }


}