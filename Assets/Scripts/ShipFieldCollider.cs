using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipFieldCollider : MonoBehaviour
{

    //661.5 267.1 1682.8 864.2

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
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[51];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)1)
            {
                battleSystem.stackeos[1]++;
                canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[1].ToString();
                if (battleSystem.stackeos[1] == 1)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[53];
                if (battleSystem.stackeos[1] == 2 || battleSystem.stackeos[1] == 3)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                if (battleSystem.stackeos[1] == 4 || battleSystem.stackeos[1] == 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                if (battleSystem.stackeos[1] > 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)2)
            {
                battleSystem.stackeos[2]++;
                canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[2].ToString();
                if (battleSystem.stackeos[2] == 1)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[58];
                if (battleSystem.stackeos[2] == 2 || battleSystem.stackeos[2] == 3)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                if (battleSystem.stackeos[2] == 4 || battleSystem.stackeos[2] == 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                if (battleSystem.stackeos[2] > 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)3)
            {
                battleSystem.stackeos[3]++;
                canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[3].ToString();
                if (battleSystem.stackeos[3] < 4)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
                if (battleSystem.stackeos[3] > 3 && battleSystem.stackeos[3] < 8)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[68];
                if (battleSystem.stackeos[3] > 7)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];

            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)4)
            {
                battleSystem.stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[4].ToString();
                if (battleSystem.stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                if (battleSystem.stackeos[4] > 5 && battleSystem.stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (battleSystem.stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)5)
            {
                battleSystem.stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[4].ToString();
                if (battleSystem.stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                if (battleSystem.stackeos[4] > 5 && battleSystem.stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (battleSystem.stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
            }
            other.GetComponent<ModuleHUD>().insideField = true;
        }

        if (other.gameObject.tag == "Member")
        {
            other.gameObject.GetComponent<MemberHUD>().insideField = true;
            switch (other.gameObject.GetComponent<MemberHUD>().profession)
            {
                case (ProfessionType)0:
                    battleSystem.mStackeos[0]++;
                    canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[0].ToString();
                    if (battleSystem.mStackeos[0] > 0 && battleSystem.mStackeos[0] < 3)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                    if (battleSystem.mStackeos[0] > 2 && battleSystem.mStackeos[0] < 6)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                    if (battleSystem.mStackeos[0] > 5)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                    break;
                case (ProfessionType)1:
                    battleSystem.mStackeos[1]++;
                    canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[1].ToString();
                    if (battleSystem.mStackeos[1] > 0 && battleSystem.mStackeos[1] < 3)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                    if (battleSystem.mStackeos[1] > 2 && battleSystem.mStackeos[1] < 6)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                    if (battleSystem.mStackeos[1] > 5)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                    break;
                case (ProfessionType)2:
                    battleSystem.mStackeos[2]++;
                    canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[2].ToString();
                    if (battleSystem.mStackeos[2] > 0 && battleSystem.mStackeos[2] < 4)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                    if (battleSystem.mStackeos[2] > 3 && battleSystem.mStackeos[2] < 8)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                    if (battleSystem.mStackeos[2] > 7)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                    break;
                case (ProfessionType)3:
                    battleSystem.mStackeos[3]++;
                    canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[3].ToString();
                    if (battleSystem.mStackeos[3] > 0 && battleSystem.mStackeos[3] < 3)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                    if (battleSystem.mStackeos[3] > 2 && battleSystem.mStackeos[3] < 6)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                    if (battleSystem.mStackeos[3] > 5)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                    break;
                case (ProfessionType)4:
                    battleSystem.mStackeos[4]++;
                    canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[4].ToString();
                    if (battleSystem.mStackeos[4] > 0 && battleSystem.mStackeos[4] < 3)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                    if (battleSystem.mStackeos[4] > 2 && battleSystem.mStackeos[4] < 6)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                    if (battleSystem.mStackeos[4] > 5)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                    break;
                case (ProfessionType)5:
                    battleSystem.mStackeos[5]++;
                    canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[5].ToString();
                    if (battleSystem.mStackeos[5] > 0 && battleSystem.mStackeos[5] < 4)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                    if (battleSystem.mStackeos[5] > 3 && battleSystem.mStackeos[5] < 6)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[22];
                    if (battleSystem.mStackeos[5] > 5)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[23];
                    break;
                case (ProfessionType)6:
                    battleSystem.mStackeos[6]++;
                    canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[6].ToString();
                    if (battleSystem.mStackeos[6] > 0 && battleSystem.mStackeos[6] < 3)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                    if (battleSystem.mStackeos[6] > 2 && battleSystem.mStackeos[6] < 6)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                    if (battleSystem.mStackeos[6] > 5)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                    break;
                case (ProfessionType)7:
                    battleSystem.mStackeos[7]++;
                    canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[7].ToString();
                    if (battleSystem.mStackeos[7] > 0 && battleSystem.mStackeos[7] < 2)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[29];
                    if (battleSystem.mStackeos[7] > 1 && battleSystem.mStackeos[7] < 4)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[30];
                    if (battleSystem.mStackeos[7] > 3)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[31];
                    break;
                case (ProfessionType)8:
                    battleSystem.mStackeos[8]++;
                    canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[8].ToString();
                    if (battleSystem.mStackeos[8] > 0 && battleSystem.mStackeos[8] < 3)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                    if (battleSystem.mStackeos[8] > 2 && battleSystem.mStackeos[8] < 6)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                    if (battleSystem.mStackeos[8] > 5)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                    break;
                case (ProfessionType)9:
                    battleSystem.mStackeos[9]++;
                    canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[9].ToString();
                    if (battleSystem.mStackeos[9] > 0 && battleSystem.mStackeos[9] < 3)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                    if (battleSystem.mStackeos[9] > 2 && battleSystem.mStackeos[9] < 6)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                    if (battleSystem.mStackeos[9] > 5)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                    break;
                case (ProfessionType)10:
                    battleSystem.mStackeos[10]++;
                    canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[10].ToString();
                    if (battleSystem.mStackeos[10] > 0 && battleSystem.mStackeos[10] < 4)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[41];
                    if (battleSystem.mStackeos[10] > 3)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[43];
                    break;
                case (ProfessionType)11:
                    battleSystem.mStackeos[11]++;
                    canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[11].ToString();
                    stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[47];
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Module")
        {

            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)0)
            {
                battleSystem.stackeos[0]--;
                canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[0].ToString();
                if (battleSystem.stackeos[0] == 0)
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[48];
                if (battleSystem.stackeos[0] > 0 && battleSystem.stackeos[0] < 4)
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                if (battleSystem.stackeos[0] > 3)
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[51];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)1)
            {
                battleSystem.stackeos[1]--;
                canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[1].ToString();
                if (battleSystem.stackeos[1] == 0)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];
                if (battleSystem.stackeos[1] == 1)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[53];
                if (battleSystem.stackeos[1] == 2 || battleSystem.stackeos[1] == 3)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                if (battleSystem.stackeos[1] == 4 || battleSystem.stackeos[1] == 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                if (battleSystem.stackeos[1] > 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)2)
            {
                battleSystem.stackeos[2]--;
                canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[2].ToString();
                if (battleSystem.stackeos[2] == 0)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];
                if (battleSystem.stackeos[2] == 1)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[58];
                if (battleSystem.stackeos[2] == 2 || battleSystem.stackeos[2] == 3)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                if (battleSystem.stackeos[2] == 4 || battleSystem.stackeos[2] == 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                if (battleSystem.stackeos[2] > 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)3)
            {
                battleSystem.stackeos[3]--;
                canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[3].ToString();
                if (battleSystem.stackeos[3] == 0)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                if (battleSystem.stackeos[3] < 4 && battleSystem.stackeos[3] > 0)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
                if (battleSystem.stackeos[3] > 3 && battleSystem.stackeos[3] < 8)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[68];
                if (battleSystem.stackeos[3] > 7)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
            }
            if (other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)4 || other.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)5)
            {
                battleSystem.stackeos[4]--;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.stackeos[4].ToString();
                if (battleSystem.stackeos[4] == 0)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];
                if (battleSystem.stackeos[4] < 6 && battleSystem.stackeos[4] > 0)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                if (battleSystem.stackeos[4] > 5 && battleSystem.stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (battleSystem.stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
            }

            other.GetComponent<ModuleHUD>().insideField = false;
        }

        if (other.gameObject.tag == "Member")
        {
            other.gameObject.GetComponent<MemberHUD>().insideField = false;
            switch (other.gameObject.GetComponent<MemberHUD>().profession)
            {
                case (ProfessionType)0:
                    battleSystem.mStackeos[0]--;
                    canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[0].ToString();
                    if (battleSystem.mStackeos[0] == 0)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[0];
                    if (battleSystem.mStackeos[0] > 0 && battleSystem.mStackeos[0] < 3)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                    if (battleSystem.mStackeos[0] > 2 && battleSystem.mStackeos[0] < 6)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                    if (battleSystem.mStackeos[0] > 5)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                    break;
                case (ProfessionType)1:
                    battleSystem.mStackeos[1]--;
                    canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[1].ToString();
                    if (battleSystem.mStackeos[1] == 0)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[4];
                    if (battleSystem.mStackeos[1] > 0 && battleSystem.mStackeos[1] < 3)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                    if (battleSystem.mStackeos[1] > 2 && battleSystem.mStackeos[1] < 6)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                    if (battleSystem.mStackeos[1] > 5)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                    break;
                case (ProfessionType)2:
                    battleSystem.mStackeos[2]--;
                    canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[2].ToString();
                    if (battleSystem.mStackeos[2] == 0)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[8];
                    if (battleSystem.mStackeos[2] > 0 && battleSystem.mStackeos[2] < 4)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                    if (battleSystem.mStackeos[2] > 3 && battleSystem.mStackeos[2] < 8)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                    if (battleSystem.mStackeos[2] > 7)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                    break;
                case (ProfessionType)3:
                    battleSystem.mStackeos[3]--;
                    canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[3].ToString();
                    if (battleSystem.mStackeos[3] == 0)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[12];
                    if (battleSystem.mStackeos[3] > 0 && battleSystem.mStackeos[3] < 3)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                    if (battleSystem.mStackeos[3] > 2 && battleSystem.mStackeos[3] < 6)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                    if (battleSystem.mStackeos[3] > 5)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                    break;
                case (ProfessionType)4:
                    battleSystem.mStackeos[4]--;
                    canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[4].ToString();
                    if (battleSystem.mStackeos[4] == 0)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[16];
                    if (battleSystem.mStackeos[4] > 0 && battleSystem.mStackeos[4] < 3)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                    if (battleSystem.mStackeos[4] > 2 && battleSystem.mStackeos[4] < 6)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                    if (battleSystem.mStackeos[4] > 5)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                    break;
                case (ProfessionType)5:
                    battleSystem.mStackeos[5]--;
                    canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[5].ToString();
                    if (battleSystem.mStackeos[5] == 0)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[20];
                    if (battleSystem.mStackeos[5] > 0 && battleSystem.mStackeos[5] < 4)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                    if (battleSystem.mStackeos[5] > 3 && battleSystem.mStackeos[5] < 6)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[22];
                    if (battleSystem.mStackeos[5] > 5)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[23];
                    break;
                case (ProfessionType)6:
                    battleSystem.mStackeos[6]--;
                    canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[6].ToString();
                    if (battleSystem.mStackeos[6] == 0)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[24];
                    if (battleSystem.mStackeos[6] > 0 && battleSystem.mStackeos[6] < 3)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                    if (battleSystem.mStackeos[6] > 2 && battleSystem.mStackeos[6] < 6)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                    if (battleSystem.mStackeos[6] > 5)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                    break;
                case (ProfessionType)7:
                    battleSystem.mStackeos[7]--;
                    canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[7].ToString();
                    if (battleSystem.mStackeos[7] == 0)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[28];
                    if (battleSystem.mStackeos[7] > 0 && battleSystem.mStackeos[7] < 2)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[29];
                    if (battleSystem.mStackeos[7] > 1 && battleSystem.mStackeos[7] < 4)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[30];
                    if (battleSystem.mStackeos[7] > 3)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[31];
                    break;
                case (ProfessionType)8:
                    battleSystem.mStackeos[8]--;
                    canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[8].ToString();
                    if (battleSystem.mStackeos[8] == 0)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[32];
                    if (battleSystem.mStackeos[8] > 0 && battleSystem.mStackeos[8] < 3)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                    if (battleSystem.mStackeos[8] > 2 && battleSystem.mStackeos[8] < 6)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                    if (battleSystem.mStackeos[8] > 5)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                    break;
                case (ProfessionType)9:
                    battleSystem.mStackeos[9]--;
                    canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[9].ToString();
                    if (battleSystem.mStackeos[9] == 0)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[36];
                    if (battleSystem.mStackeos[9] > 0 && battleSystem.mStackeos[9] < 3)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                    if (battleSystem.mStackeos[9] > 2 && battleSystem.mStackeos[9] < 6)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                    if (battleSystem.mStackeos[9] > 5)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                    break;
                case (ProfessionType)10:
                    battleSystem.mStackeos[10]--;
                    canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[10].ToString();
                    if (battleSystem.mStackeos[10] == 0)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[40];
                    if (battleSystem.mStackeos[10] > 0 && battleSystem.mStackeos[10] < 4)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[41];
                    if (battleSystem.mStackeos[10] > 3)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[43];
                    break;
                case (ProfessionType)11:
                    battleSystem.mStackeos[11]--;
                    canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[11].ToString();
                    if (battleSystem.mStackeos[11] == 0)
                        stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[44];
                    if (battleSystem.mStackeos[11] > 0)
                        stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[47];
                    break;

            }
        }
    }
}
