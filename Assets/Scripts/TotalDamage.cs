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
        int crewPerformance = 0;
        foreach (GameObject member in members)
        {
            float performance = member.GetComponent<MemberHUD>().performance;
            if (member.gameObject.GetComponent<MemberHUD>().insideField)
            {
                if (performance >= 0 && performance < 5)
                    crewPerformance += 4;
                if (performance >= 5 && performance < 10)
                    crewPerformance += 6;
                if (performance >= 10 && performance < 15)
                    crewPerformance += 8;
                if (performance >= 15 && performance < 20)
                    crewPerformance += 10;
                if (performance >= 20 && performance < 25)
                    crewPerformance += 12;
                if (performance >= 25 && performance < 30)
                    crewPerformance += 14;
                if (performance >= 30 && performance < 35)
                    crewPerformance += 16;
                if (performance >= 35 && performance < 40)
                    crewPerformance += 18;
                if (performance >= 40 && performance < 45)
                    crewPerformance += 20;
                if (performance >= 45 && performance < 50)
                    crewPerformance += 25;
                if (performance >= 50 && performance < 55)
                    crewPerformance += 30;
                if (performance >= 55 && performance < 60)
                    crewPerformance += 35;
                if (performance >= 60 && performance < 65)
                    crewPerformance += 40;
                if (performance >= 65 && performance < 70)
                    crewPerformance += 45;
                if (performance >= 70 && performance < 75)
                    crewPerformance += 50;
                if (performance >= 75 && performance < 80)
                    crewPerformance += 55;
                if (performance >= 80 && performance < 85)
                    crewPerformance += 60;
                if (performance >= 85 && performance < 90)
                    crewPerformance += 65;
                if (performance >= 90 && performance < 95)
                    crewPerformance += 70;
                if (performance >= 95 && performance < 100)
                    crewPerformance += 75;
                if (performance == 100)
                    crewPerformance += 100;
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
