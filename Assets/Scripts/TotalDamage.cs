using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDamage : MonoBehaviour
{

    public GameObject battleSystem;
    public GameObject displayer;

    void Update()
    {
        List<GameObject> members = battleSystem.GetComponent<BattleSystem>().members;
        int crewPerformance = 100;
        foreach (GameObject member in members)
        {
            float performance = member.GetComponent<MemberHUD>().performance;
            if (performance < 20)
                crewPerformance += 3;
            if (performance >= 20 && performance< 39)
                crewPerformance += 6;
            if (performance >= 40 && performance< 59)
                crewPerformance += 10;
            if (performance >= 60 && performance< 79)
                crewPerformance += 20;
            if (performance >= 80 && performance< 99)
                crewPerformance += 30;
            if (performance == 100)
                crewPerformance += 40;
        }
        displayer.GetComponent<TextMeshProUGUI>().text = crewPerformance.ToString();
    }
}
