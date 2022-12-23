using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBosses : MonoBehaviour
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
                random = Random.Range(8, 10);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                break;
            case 1:
                random = Random.Range(19, 21);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                break;
            case 2:
                random = Random.Range(32, 34);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                break;
            case 3:
                random = Random.Range(44, 46);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                break;
            case 4:
                random = Random.Range(53, 56);
                malla.transform.GetChild(34).GetComponent<SpriteRenderer>().sprite = monsters.icons[random];
                break;
        }
    }
}
