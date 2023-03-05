using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GenerateBosses : MonoBehaviour
{

    public GameObject malla;
    public GameObject malla2;
    public Monsters monsters;
    private int index;
    public GameObject enemyHB;
    public GameObject monster;
    public GameObject monsterName;
    public EnemiesExcel enemiesExcel;

    private void Start()
    {
        string[] enemiesData = Resources.Load<TextAsset>("Excel/Enemies").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = (enemiesData.Length / 8) - 1;
        enemiesExcel.myEnemies.enemies = new EnemiesExcel.Enemy[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            enemiesExcel.myEnemies.enemies[i] = new EnemiesExcel.Enemy();
            enemiesExcel.myEnemies.enemies[i].name = enemiesData[(8 * (i + 1))];
            enemiesExcel.myEnemies.enemies[i].health = int.Parse(enemiesData[(8 * (i + 1)) + 1]);
            enemiesExcel.myEnemies.enemies[i].dPT = int.Parse(enemiesData[(8 * (i + 1)) + 2]);
            enemiesExcel.myEnemies.enemies[i].effect = enemiesData[(8 * (i + 1)) + 3];
            enemiesExcel.myEnemies.enemies[i].effect = enemiesExcel.myEnemies.enemies[i].effect.Replace("*", ",");
            enemiesExcel.myEnemies.enemies[i].flavour = enemiesData[(8 * (i + 1)) + 4];
            enemiesExcel.myEnemies.enemies[i].flavour = enemiesExcel.myEnemies.enemies[i].flavour.Replace("*", ",");
            enemiesExcel.myEnemies.enemies[i].level = int.Parse(enemiesData[(8 * (i + 1)) + 5]);
            if (enemiesData[(8 * (i + 1)) + 6] == "Boss")
                enemiesExcel.myEnemies.enemies[i].type = true;
            else
                enemiesExcel.myEnemies.enemies[i].type = false;
            enemiesExcel.myEnemies.enemies[i].crewDMG = int.Parse(enemiesData[(8 * (i + 1)) + 7]);
        }
    }


    public void Generate()
    {
        int random = 0;
        index = malla2.transform.GetComponent<MapSwitcher>().index;
        monster.SetActive(true);
        if (monster.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Monster_Scope") && monster.GetComponent<SpriteRenderer>().sprite != null)
        {
            monster.GetComponent<Animator>().Play("Monster_Idle");
            return;
        }
        else
        {
            switch (index)
            {
                case 0:
                    random = 4;
                    break;
                case 1:
                    random = 9;
                    break;
                case 2:
                    random = UnityEngine.Random.Range(19, 21);
                    break;
                case 3:
                    random = UnityEngine.Random.Range(32, 34);
                    break;
                case 4:
                    random = UnityEngine.Random.Range(44, 46);
                    break;
                case 5:
                    random = UnityEngine.Random.Range(53, 56);
                    break;

            }
            malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = enemiesExcel.myEnemies.enemies[random].effect;
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = enemiesExcel.myEnemies.enemies[random].flavour;
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = enemiesExcel.myEnemies.enemies[random].name;
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = enemiesExcel.myEnemies.enemies[random].dPT;
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = enemiesExcel.myEnemies.enemies[random].health;
            malla.transform.GetChild(34).GetComponent<MonsterHUD>().crewDMG = enemiesExcel.myEnemies.enemies[random].crewDMG;
            enemyHB.transform.GetComponent<Slider>().maxValue = enemiesExcel.myEnemies.enemies[random].health;
            enemyHB.transform.GetComponent<Slider>().value = enemiesExcel.myEnemies.enemies[random].health;
            enemyHB.transform.GetChild(3).GetComponent<Text>().text = enemiesExcel.myEnemies.enemies[random].health.ToString() + " HP / " + enemiesExcel.myEnemies.enemies[random].health.ToString() + " HP";
            enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = enemiesExcel.myEnemies.enemies[random].dPT + " DPT ";
            monsterName.gameObject.SetActive(false);
            monster.GetComponent<Animator>().Play("Monster_Scope");
        }
        monsterName.gameObject.SetActive(false);
        monster.GetComponent<Animator>().Play("Monster_Scope");
        }

    private void Update()
    {
        if (monster.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Monster_Scope"))
            monsterName.gameObject.SetActive(false);
        else
            monsterName.gameObject.SetActive(true);
    }

}
