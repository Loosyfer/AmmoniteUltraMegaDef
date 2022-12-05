using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetReq : MonoBehaviour
{

    public Text myText;
    public MegaHUD apoyo;

    void Start()
    {
        myText = GetComponent<Text>();
        apoyo = transform.parent.parent.GetComponent<MegaHUD>();
        myText.text = apoyo.req.text;
    }
}
