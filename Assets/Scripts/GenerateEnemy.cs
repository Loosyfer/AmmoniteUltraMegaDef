using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{

    public GameObject malla;
    public GameObject malla2;
    public Monsters monsters;
    private int index;

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
                break;
            case 1:
                random = Random.Range(10, 19);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                break;
            case 2:
                random = Random.Range(22, 32);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                break;
            case 3:
                random = Random.Range(34, 44);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                break;
            case 4:
                random = Random.Range(46, 53);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().instructions = monsters.instructions[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().flavour = monsters.flavour[random];
                malla.transform.GetChild(34).GetComponent<MonsterHUD>().name = monsters.names[random];
                break;
        }
        
    }
}
