using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTrait : MonoBehaviour
{

    public MemberHUD script1;
    private BattleSystem script2;
    private Text trait;
    private int index;
    private GameObject supp;

    public void Change(string s)
    {
        supp = GameObject.Find("/Battle System");
        script2 = supp.GetComponent<BattleSystem>();
        index = int.Parse(s);
        trait = script1.trait;
        trait.text = script2.membersInfo.traitList[index];
    }
}
