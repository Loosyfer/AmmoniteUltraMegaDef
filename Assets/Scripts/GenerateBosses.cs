using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateBosses : MonoBehaviour
{

    public GameObject malla;
    public GameObject malla2;
    public Monsters monsters;
    private int index;
    public GameObject enemyHB;
    public GameObject monster;
    public GameObject monsterName;

    public void Generate()
    {
        int random;
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
                    random = Random.Range(8, 10);
                    malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                    enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                    enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = monster.transform.GetComponent<MonsterHUD>().dPT + " DPT ";
                    break;
                case 1:
                    random = Random.Range(19, 21);
                    malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                    enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                    enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = monster.transform.GetComponent<MonsterHUD>().dPT + " DPT ";
                    break;
                case 2:
                    random = Random.Range(32, 34);
                    malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                    enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                    enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = monster.transform.GetComponent<MonsterHUD>().dPT + " DPT ";
                    break;
                case 3:
                    random = Random.Range(44, 46);
                    malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                    enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                    enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = monster.transform.GetComponent<MonsterHUD>().dPT + " DPT ";
                    break;
                case 4:
                    random = Random.Range(53, 56);
                    malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                    malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                    enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                    enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                    enemyHB.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = monster.transform.GetComponent<MonsterHUD>().dPT + " DPT ";
                    break;
            }
            monsterName.gameObject.SetActive(false);
            monster.GetComponent<Animator>().Play("Monster_Scope");
        }
    }
}
