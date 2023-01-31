using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDamage : MonoBehaviour
{

    public GameObject battleSystem;
    public GameObject displayer1;
    public GameObject displayer2;
    public GameObject displayer3;
    public int extraDmg;
    public int sum;

    void Awake()
    {
        extraDmg = 0;
        sum = 0;
    }

    void Update()
    {
        List<GameObject> members = battleSystem.GetComponent<BattleSystem>().members;
        int crewPerformance = 20;
        foreach (GameObject member in members)
        {
            float performance = member.GetComponent<MemberHUD>().performance;
            if (member.gameObject.GetComponent<MemberHUD>().insideField)
            {
                if (performance >= 0 && performance < 10)
                    crewPerformance += 1;
                if (performance >= 10 && performance < 20)
                    crewPerformance += 3;
                if (performance >= 20 && performance < 30)
                    crewPerformance += 6;
                if (performance >= 30 && performance < 40)
                    crewPerformance += 10;
                if (performance >= 40 && performance < 50)
                    crewPerformance += 14;
                if (performance >= 50 && performance < 60)
                    crewPerformance += 18;
                if (performance >= 60 && performance < 70)
                    crewPerformance += 22;
                if (performance >= 70 && performance < 80)
                    crewPerformance += 26;
                if (performance >= 80 && performance < 90)
                    crewPerformance += 30;
                if (performance >= 90 && performance < 100)
                    crewPerformance += 34;
                if (performance == 100)
                    crewPerformance += 40;
            }
        }
        displayer1.GetComponent<TextMeshProUGUI>().text = crewPerformance.ToString();
        displayer2.GetComponent<TextMeshProUGUI>().text = extraDmg.ToString();
        sum = crewPerformance + extraDmg;
        displayer3.GetComponent<TextMeshProUGUI>().text = sum.ToString();
    }

    public void updateExtraDmg(string s)
    {
        extraDmg = int.Parse(s);
    }
}
