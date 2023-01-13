using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEnemy : MonoBehaviour
{

    public GameObject malla;
    public GameObject malla2;
    public Monsters monsters;
    private int index;
    public GameObject enemyHB;

    public void Generate()
    {
        int random;
        index = malla2.transform.GetComponent<MapSwitcher>().index;
        switch (index)
        {
            case 0:
                random = Random.Range(0, 8);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                break;
            case 1:
                random = Random.Range(10, 19);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                break;
            case 2:
                random = Random.Range(22, 32);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                break;
            case 3:
                random = Random.Range(34, 44);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                break;
            case 4:
                random = Random.Range(46, 53);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().dPT = monsters.dPT[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().health = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().maxValue = monsters.health[random];
                enemyHB.transform.GetComponent<Slider>().value = monsters.health[random];
                enemyHB.transform.GetChild(3).GetComponent<Text>().text = monsters.health[random].ToString() + " HP / " + monsters.health[random].ToString() + " HP";
                break;
        }
        
    }
}
