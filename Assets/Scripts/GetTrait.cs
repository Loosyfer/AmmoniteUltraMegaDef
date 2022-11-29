using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTrait : MonoBehaviour
{

    public Text myText;
    //public MemberHUD apoyo;

    void Start()
    {
        myText = GetComponent<Text>();
        //apoyo = transform.parent.GetComponent<MemberHUD>();
        //myText.text = apoyo.trait.text;
    }
}
