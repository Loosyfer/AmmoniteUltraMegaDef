using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetReq : MonoBehaviour
{

    public Text myText;
    public ModuleHUD apoyo;

    void Start()
    {
        myText = GetComponent<Text>();
        apoyo = transform.parent.parent.GetComponent<ModuleHUD>();
        myText.text = apoyo.req.ToString();
    }
}
