using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipFieldCollider : MonoBehaviour
{

    public BattleSystem battleSystem;
    public GameObject canvas;
    public GameObject stackingFolder;
    public StackingIcons stackingIcons;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Module")
        {
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)0)
            {
                battleSystem.stackeos[0]++;
                canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[0].ToString();
                if (battleSystem.stackeos[0] < 4)
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                else
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)1)
            {
                battleSystem.stackeos[1]++;
                canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[1].ToString();
                if (battleSystem.stackeos[1] == 1)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                if (battleSystem.stackeos[1] == 2 || battleSystem.stackeos[1] == 3)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                if (battleSystem.stackeos[1] == 4 || battleSystem.stackeos[1] == 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
                if (battleSystem.stackeos[1] > 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)2)
            {
                battleSystem.stackeos[2]++;
                canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[2].ToString();
                if (battleSystem.stackeos[2] == 1)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                if (battleSystem.stackeos[2] == 2 || battleSystem.stackeos[1] == 3)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                if (battleSystem.stackeos[2] == 4 || battleSystem.stackeos[1] == 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
                if (battleSystem.stackeos[2] > 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)3)
            {
                battleSystem.stackeos[3]++;
                canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[3].ToString();
                if (battleSystem.stackeos[3] < 4)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
                if (battleSystem.stackeos[3] > 3 && battleSystem.stackeos[3] < 8)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
                if (battleSystem.stackeos[3] > 7)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];

            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)4)
            {
                battleSystem.stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[4].ToString();
                if (battleSystem.stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (battleSystem.stackeos[4] > 5 && battleSystem.stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                if (battleSystem.stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)5)
            {
                battleSystem.stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[4].ToString();
                if (battleSystem.stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (battleSystem.stackeos[4] > 5 && battleSystem.stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                if (battleSystem.stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
            }
            other.GetComponent<ModuleHUD>().insideField = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Module")
            other.GetComponent<ModuleHUD>().insideField = false;
    }
}
