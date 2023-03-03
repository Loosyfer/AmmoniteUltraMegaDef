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
        extraDmg = 10;
        sum = 0;
    }

    void Update()
    {
        List<GameObject> members = battleSystem.GetComponent<BattleSystem>().members;
        int crewPerformance = 0;
        foreach (GameObject member in members)
        {
            float performance = member.GetComponent<MemberHUD>().performance;
            if (member.gameObject.GetComponent<MemberHUD>().insideField)
            {
                if (performance >= 0 && performance < 5)
                    crewPerformance += 0;
                if (performance >= 5 && performance < 10)
                    crewPerformance += 2;
                if (performance >= 10 && performance < 15)
                    crewPerformance += 2;
                if (performance >= 15 && performance < 20)
                    crewPerformance += 2;
                if (performance >= 20 && performance < 25)
                    crewPerformance += 4;
                if (performance >= 25 && performance < 30)
                    crewPerformance += 4;
                if (performance >= 30 && performance < 35)
                    crewPerformance += 6;
                if (performance >= 35 && performance < 40)
                    crewPerformance += 8;
                if (performance >= 40 && performance < 45)
                    crewPerformance += 10;
                if (performance >= 45 && performance < 50)
                    crewPerformance += 13;
                if (performance >= 50 && performance < 55)
                    crewPerformance += 16;
                if (performance >= 55 && performance < 60)
                    crewPerformance += 20;
                if (performance >= 60 && performance < 65)
                    crewPerformance += 24;
                if (performance >= 65 && performance < 70)
                    crewPerformance += 28;
                if (performance >= 70 && performance < 75)
                    crewPerformance += 33;
                if (performance >= 75 && performance < 80)
                    crewPerformance += 38;
                if (performance >= 80 && performance < 85)
                    crewPerformance += 44;
                if (performance >= 85 && performance < 90)
                    crewPerformance += 50;
                if (performance >= 90 && performance < 95)
                    crewPerformance += 57;
                if (performance >= 95 && performance < 100)
                    crewPerformance += 64;
                if (performance >= 100 && performance < 105)
                    crewPerformance += 74;
                if (performance >= 105 && performance < 110)
                    crewPerformance += 82;
                if (performance >= 110 && performance < 115)
                    crewPerformance += 90;
                if (performance >= 115 && performance < 120)
                    crewPerformance += 98;
                if (performance >= 120)
                    crewPerformance += 106;
            
            }
        }
        displayer1.GetComponent<TextMeshProUGUI>().text = crewPerformance.ToString();
        displayer2.GetComponent<TextMeshProUGUI>().text = extraDmg.ToString();
        sum = crewPerformance + extraDmg;
        displayer3.GetComponent<TextMeshProUGUI>().text = sum.ToString();
    }

    public void updateExtraDmg(string s)
    {
        extraDmg = int.Parse(s) + extraDmg;
    }
}
