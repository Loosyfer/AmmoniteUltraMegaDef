using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeProfession : MonoBehaviour
{

    public MemInfo script;
    private int index;
    public BattleSystem battleSystem;

    public void Change(string s)
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            int oldProfId = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().professionId;
            if (int.TryParse(s, out int index))
            {
                GameObject canvas = GameObject.Find("/Malla");
                battleSystem.mStackeos[index]++;
                switch (index)
                {
                    case 0:
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[0].ToString();
                        if (battleSystem.mStackeos[0] > 0 && battleSystem.mStackeos[0] < 4)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[1];
                        if (battleSystem.mStackeos[0] >= 4 && battleSystem.mStackeos[0] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[2];
                        if (battleSystem.mStackeos[0] >= 8 && battleSystem.mStackeos[0] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[3];
                        if (battleSystem.mStackeos[0] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[70];
                        break;
                    case 1:
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[1].ToString();
                        if (battleSystem.mStackeos[1] > 0 && battleSystem.mStackeos[1] < 4)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[5];
                        if (battleSystem.mStackeos[1] >= 4 && battleSystem.mStackeos[1] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[6];
                        if (battleSystem.mStackeos[1] >= 8 && battleSystem.mStackeos[1] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[7];
                        if (battleSystem.mStackeos[1] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[74];
                        break;
                    case 2:
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[2].ToString();
                        if (battleSystem.mStackeos[2] > 0 && battleSystem.mStackeos[2] < 4)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[9];
                        if (battleSystem.mStackeos[2] >= 4 && battleSystem.mStackeos[2] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[10];
                        if (battleSystem.mStackeos[2] >= 8 && battleSystem.mStackeos[2] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[11];
                        if (battleSystem.mStackeos[2] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[73];
                        break;
                    case 3:
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[3].ToString();
                        if (battleSystem.mStackeos[3] > 0 && battleSystem.mStackeos[3] < 4)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[13];
                        if (battleSystem.mStackeos[3] >= 4 && battleSystem.mStackeos[3] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[14];
                        if (battleSystem.mStackeos[3] >= 8 && battleSystem.mStackeos[3] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[15];
                        if (battleSystem.mStackeos[3] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[77];
                        break;
                    case 4:
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[4].ToString();
                        if (battleSystem.mStackeos[4] > 0 && battleSystem.mStackeos[4] < 4)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[17];
                        if (battleSystem.mStackeos[4] >= 4 && battleSystem.mStackeos[4] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[18];
                        if (battleSystem.mStackeos[4] >= 8 && battleSystem.mStackeos[4] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[19];
                        if (battleSystem.mStackeos[4] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[76];
                        break;
                    case 5:
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[5].ToString();
                        battleSystem.stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[21];
                        break;
                    case 6:
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[6].ToString();
                        if (battleSystem.mStackeos[6] > 0 && battleSystem.mStackeos[6] < 4)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[25];
                        if (battleSystem.mStackeos[6] >= 4 && battleSystem.mStackeos[6] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[26];
                        if (battleSystem.mStackeos[6] >= 8 && battleSystem.mStackeos[6] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[27];
                        if (battleSystem.mStackeos[6] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[78];
                        break;
                    case 7:
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[7].ToString();
                        battleSystem.stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[75];
                        break;
                    case 8:
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[8].ToString();
                        if (battleSystem.mStackeos[8] > 0 && battleSystem.mStackeos[8] < 4)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[33];
                        if (battleSystem.mStackeos[8] >= 4 && battleSystem.mStackeos[8] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[34];
                        if (battleSystem.mStackeos[8] >= 8 && battleSystem.mStackeos[8] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[35];
                        if (battleSystem.mStackeos[8] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[80];
                        break;
                    case 9:
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[9].ToString();
                        if (battleSystem.mStackeos[9] > 0 && battleSystem.mStackeos[9] < 4)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[37];
                        if (battleSystem.mStackeos[9] >= 4 && battleSystem.mStackeos[9] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[38];
                        if (battleSystem.mStackeos[9] >= 8 && battleSystem.mStackeos[9] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[39];
                        if (battleSystem.mStackeos[9] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[81];
                        break;
                    case 10:
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[10].ToString();
                        battleSystem.stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[71];
                        break;
                    case 11:
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[11].ToString();
                        battleSystem.stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[72];
                        break;
                    case 12:
                        canvas.transform.GetChild(30).GetChild(17).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[12].ToString();
                        if (battleSystem.mStackeos[12] > 0 && battleSystem.mStackeos[12] < 4)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[84];
                        if (battleSystem.mStackeos[12] >= 4 && battleSystem.mStackeos[12] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[86];
                        if (battleSystem.mStackeos[12] >= 8 && battleSystem.mStackeos[12] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[88];
                        if (battleSystem.mStackeos[12] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[90];
                        break;
                    case 13:
                        canvas.transform.GetChild(30).GetChild(18).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[13].ToString();
                        if (battleSystem.mStackeos[13] > 0 && battleSystem.mStackeos[13] < 4)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[85];
                        if (battleSystem.mStackeos[13] >= 4 && battleSystem.mStackeos[13] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[87];
                        if (battleSystem.mStackeos[13] >= 8 && battleSystem.mStackeos[13] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[89];
                        if (battleSystem.mStackeos[13] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[91];
                        break;
                }
                battleSystem.mStackeos[oldProfId]--;
                switch (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[0].ToString();
                        if (battleSystem.mStackeos[0] == 0)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[0];
                        if (battleSystem.mStackeos[0] > 0 && battleSystem.mStackeos[0] < 4)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[1];
                        if (battleSystem.mStackeos[0] >= 4 && battleSystem.mStackeos[0] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[2];
                        if (battleSystem.mStackeos[0] >= 8 && battleSystem.mStackeos[0] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[3];
                        if (battleSystem.mStackeos[0] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[70];
                        break;
                    case (ProfessionType)1:
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[1].ToString();
                        if (battleSystem.mStackeos[1] == 0)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[4];
                        if (battleSystem.mStackeos[1] > 0 && battleSystem.mStackeos[1] < 4)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[5];
                        if (battleSystem.mStackeos[1] >= 4 && battleSystem.mStackeos[1] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[6];
                        if (battleSystem.mStackeos[1] >= 8 && battleSystem.mStackeos[1] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[7];
                        if (battleSystem.mStackeos[1] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[74];
                        break;
                    case (ProfessionType)2:
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[2].ToString();
                        if (battleSystem.mStackeos[2] == 0)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[8];
                        if (battleSystem.mStackeos[2] > 0 && battleSystem.mStackeos[2] < 4)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[9];
                        if (battleSystem.mStackeos[2] >= 4 && battleSystem.mStackeos[2] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[10];
                        if (battleSystem.mStackeos[2] >= 8 && battleSystem.mStackeos[2] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[11];
                        if (battleSystem.mStackeos[2] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[73];
                        break;
                    case (ProfessionType)3:
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[3].ToString();
                        if (battleSystem.mStackeos[3] == 0)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[12];
                        if (battleSystem.mStackeos[3] > 0 && battleSystem.mStackeos[3] < 4)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[13];
                        if (battleSystem.mStackeos[3] >= 4 && battleSystem.mStackeos[3] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[14];
                        if (battleSystem.mStackeos[3] >= 8 && battleSystem.mStackeos[3] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[15];
                        if (battleSystem.mStackeos[3] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[77];
                        break;
                    case (ProfessionType)4:
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[4].ToString();
                        if (battleSystem.mStackeos[4] == 0)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[16];
                        if (battleSystem.mStackeos[4] > 0 && battleSystem.mStackeos[4] < 4)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[17];
                        if (battleSystem.mStackeos[4] >= 4 && battleSystem.mStackeos[4] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[18];
                        if (battleSystem.mStackeos[4] >= 8 && battleSystem.mStackeos[4] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[19];
                        if (battleSystem.mStackeos[4] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[76];
                        break;
                    case (ProfessionType)5:
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[5].ToString();
                        if (battleSystem.mStackeos[5] == 0)
                            battleSystem.stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[20];
                        else
                            battleSystem.stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[21];
                        break;
                    case (ProfessionType)6:
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[6].ToString();
                        if (battleSystem.mStackeos[6] == 0)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[24];
                        if (battleSystem.mStackeos[6] > 0 && battleSystem.mStackeos[6] < 4)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[25];
                        if (battleSystem.mStackeos[6] >= 4 && battleSystem.mStackeos[6] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[26];
                        if (battleSystem.mStackeos[6] >= 8 && battleSystem.mStackeos[6] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[27];
                        if (battleSystem.mStackeos[6] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[78];
                        break;
                    case (ProfessionType)7:
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[7].ToString();
                        if (battleSystem.mStackeos[7] == 0)
                            battleSystem.stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[28];
                        else
                            battleSystem.stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[75];
                        break;
                    case (ProfessionType)8:
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[8].ToString();
                        if (battleSystem.mStackeos[8] == 0)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[32];
                        if (battleSystem.mStackeos[8] > 0 && battleSystem.mStackeos[8] < 4)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[33];
                        if (battleSystem.mStackeos[8] >= 4 && battleSystem.mStackeos[8] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[34];
                        if (battleSystem.mStackeos[8] >= 8 && battleSystem.mStackeos[8] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[35];
                        if (battleSystem.mStackeos[8] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[80];
                        break;
                    case (ProfessionType)9:
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[9].ToString();
                        if (battleSystem.mStackeos[9] == 0)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[36];
                        if (battleSystem.mStackeos[9] > 0 && battleSystem.mStackeos[9] < 4)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[37];
                        if (battleSystem.mStackeos[9] >= 4 && battleSystem.mStackeos[9] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[38];
                        if (battleSystem.mStackeos[9] >= 8 && battleSystem.mStackeos[9] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[39];
                        if (battleSystem.mStackeos[9] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[81];
                        break;
                    case (ProfessionType)10:
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[10].ToString();
                        if (battleSystem.mStackeos[10] == 0)
                            battleSystem.stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[40];
                        else
                            battleSystem.stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[71];
                        break;
                    case (ProfessionType)11:
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[11].ToString();
                        if (battleSystem.mStackeos[11] == 0)
                            battleSystem.stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[44];
                        else
                            battleSystem.stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[72];
                        break;
                    case (ProfessionType)12:
                        canvas.transform.GetChild(30).GetChild(17).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[12].ToString();
                        if (battleSystem.mStackeos[12] == 0)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[82];
                        if (battleSystem.mStackeos[12] > 0 && battleSystem.mStackeos[12] < 4)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[84];
                        if (battleSystem.mStackeos[12] >= 4 && battleSystem.mStackeos[12] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[86];
                        if (battleSystem.mStackeos[12] >= 8 && battleSystem.mStackeos[12] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[88];
                        if (battleSystem.mStackeos[12] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[90];
                        break;
                    case (ProfessionType)13:
                        canvas.transform.GetChild(30).GetChild(18).GetChild(0).GetComponent<TMP_Text>().text = battleSystem.mStackeos[13].ToString();
                        if (battleSystem.mStackeos[13] == 0)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[83];
                        if (battleSystem.mStackeos[13] > 0 && battleSystem.mStackeos[13] < 4)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[85];
                        if (battleSystem.mStackeos[13] >= 4 && battleSystem.mStackeos[13] <= 7)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[87];
                        if (battleSystem.mStackeos[13] >= 8 && battleSystem.mStackeos[13] <= 11)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[89];
                        if (battleSystem.mStackeos[13] >= 12)
                            battleSystem.stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = battleSystem.stackingIcons.sprites[91];
                        break;

                }

                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().professionId = index;
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profession = (ProfessionType)index;
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>().profDetailsText.text = script.profDescription[index];
                transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.transform.GetChild(2).GetComponent<GetProfession>().UpdateProf();
            }
        }
    }
}
