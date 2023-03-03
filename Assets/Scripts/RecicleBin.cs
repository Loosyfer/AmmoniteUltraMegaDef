using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RecicleBin : MonoBehaviour, IDropHandler
{

    public Camera camera;
    public BattleSystem script;
    [SerializeField]
    public GameObject stackingFolder;
    public StackingIcons stackingIcons;
    public ItemSpawner itemSpawner;


    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            GameObject canvas = GameObject.Find("/Malla");
            if (eventData.pointerDrag.tag == "Module")
            {
                script.modules.Remove(eventData.pointerDrag);
                /*if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)0)
                {
                    script.stackeos[0]--;
                    canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = script.stackeos[0].ToString();
                    if (script.stackeos[0] == 0)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[48];
                    if (script.stackeos[0] > 0 && script.stackeos[0] < 4)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                    if (script.stackeos[0] > 3)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)1)
                {
                    script.stackeos[1]--;
                    canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = script.stackeos[1].ToString();
                    if (script.stackeos[1] == 0)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[53];
                    if (script.stackeos[1] == 1)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                    if (script.stackeos[1] == 2 || script.stackeos[1] == 3)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                    if (script.stackeos[1] == 4 || script.stackeos[1] == 5)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
                    if (script.stackeos[1] > 5)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)2)
                {
                    script.stackeos[2]--;
                    canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = script.stackeos[2].ToString();
                    if (script.stackeos[2] == 0)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[58];
                    if (script.stackeos[2] == 1)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                    if (script.stackeos[2] == 2 || script.stackeos[1] == 3)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                    if (script.stackeos[2] == 4 || script.stackeos[1] == 5)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
                    if (script.stackeos[2] > 5)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)3)
                {
                    script.stackeos[3]--;
                    canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = script.stackeos[3].ToString();
                    if (script.stackeos[3] == 0)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[68];
                    if (script.stackeos[3] < 4 && script.stackeos[3] > 0)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
                    if (script.stackeos[3] > 3 && script.stackeos[3] < 8)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
                    if (script.stackeos[3] > 7)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)4 || eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)5)
                {
                    script.stackeos[4]--;
                    canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = script.stackeos[4].ToString();
                    if (script.stackeos[4] == 0)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                    if (script.stackeos[4] < 6 && script.stackeos[4] > 0 )
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                    if (script.stackeos[4] > 5 && script.stackeos[4] < 10)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                    if (script.stackeos[4] > 9)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
                }*/
            }
            if (eventData.pointerDrag.tag == "Member")
            {
                /*switch (eventData.pointerDrag.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        script.
                
                
                
                
                
                [0]--;
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[0].ToString();
                        if (script.mStackeos[0] == 0)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[0];
                        if (script.mStackeos[0] > 0 && script.mStackeos[0] < 3)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                        if (script.mStackeos[0] > 2 && script.mStackeos[0] < 6)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                        if (script.mStackeos[0] > 5)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                        break;
                    case (ProfessionType)1:
                        script.mStackeos[1]--;
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[1].ToString();
                        if (script.mStackeos[1] == 0)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[4];
                        if (script.mStackeos[1] > 0 && script.mStackeos[1] < 3)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                        if (script.mStackeos[1] > 2 && script.mStackeos[1] < 6)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                        if (script.mStackeos[1] > 5)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                        break;
                    case (ProfessionType)2:
                        script.mStackeos[2]--;
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[2].ToString();
                        if (script.mStackeos[2] == 0)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[8];
                        if (script.mStackeos[2] > 0 && script.mStackeos[2] < 4)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                        if (script.mStackeos[2] > 3 && script.mStackeos[2] < 8)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                        if (script.mStackeos[2] > 7)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                        break;
                    case (ProfessionType)3:
                        script.mStackeos[3]--;
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[3].ToString();
                        if (script.mStackeos[3] == 0)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[12];
                        if (script.mStackeos[3] > 0 && script.mStackeos[3] < 3)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                        if (script.mStackeos[3] > 2 && script.mStackeos[3] < 6)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                        if (script.mStackeos[3] > 5)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                        break;
                    case (ProfessionType)4:
                        script.mStackeos[4]--;
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[4].ToString();
                        if (script.mStackeos[4] == 0)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[16];
                        if (script.mStackeos[4] > 0 && script.mStackeos[4] < 3)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                        if (script.mStackeos[4] > 2 && script.mStackeos[4] < 6)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                        if (script.mStackeos[4] > 5)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                        break;
                    case (ProfessionType)5:
                        script.mStackeos[5]--;
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[5].ToString();
                        if (script.mStackeos[5] == 0)
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[20];
                        if (script.mStackeos[5] > 0 && script.mStackeos[5] < 4)
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                        if (script.mStackeos[5] > 3 && script.mStackeos[5] < 6)
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[22];
                        if (script.mStackeos[5] > 5)
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[23];
                        break;
                    case (ProfessionType)6:
                        script.mStackeos[6]--;
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[6].ToString();
                        if (script.mStackeos[6] == 0)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[24];
                        if (script.mStackeos[6] > 0 && script.mStackeos[6] < 3)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                        if (script.mStackeos[6] > 2 && script.mStackeos[6] < 6)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                        if (script.mStackeos[6] > 5)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                        break;
                    case (ProfessionType)7:
                        script.mStackeos[7]--;
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[7].ToString();
                        if (script.mStackeos[7] == 0)
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[28];
                        if (script.mStackeos[7] > 0 && script.mStackeos[7] < 2)
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[29];
                        if (script.mStackeos[7] > 1 && script.mStackeos[7] < 4)
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[30];
                        if (script.mStackeos[7] > 3)
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[31];
                        break;
                    case (ProfessionType)8:
                        script.mStackeos[8]--;
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[8].ToString();
                        if (script.mStackeos[8] == 0)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[32];
                        if (script.mStackeos[8] > 0 && script.mStackeos[8] < 3)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                        if (script.mStackeos[8] > 2 && script.mStackeos[8] < 6)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                        if (script.mStackeos[8] > 5)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                        break;
                    case (ProfessionType)9:
                        script.mStackeos[9]--;
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[9].ToString();
                        if (script.mStackeos[9] == 0)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[36];
                        if (script.mStackeos[9] > 0 && script.mStackeos[9] < 3)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                        if (script.mStackeos[9] > 2 && script.mStackeos[9] < 6)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                        if (script.mStackeos[9] > 5)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                        break;
                    case (ProfessionType)10:
                        script.mStackeos[10]--;
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[10].ToString();
                        if (script.mStackeos[10] == 0)
                            stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[40];
                        if (script.mStackeos[10] > 0 && script.mStackeos[10] < 4)
                            stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[41];
                        if (script.mStackeos[10] > 3)
                            stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[43];
                        break;
                    case (ProfessionType)11:
                        script.mStackeos[11]--;
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[11].ToString();
                        if (script.mStackeos[11] == 0)
                            stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[44];
                        if (script.mStackeos[11] > 0)
                            stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[47];
                        break;
                }*/
                script.members.Remove(eventData.pointerDrag);
            }
            if (eventData.pointerDrag.tag == "Item")
            {
                itemSpawner.objectListId.RemoveAt(itemSpawner.objectList.IndexOf(eventData.pointerDrag));
                itemSpawner.objectList.Remove(eventData.pointerDrag);
            }

            if (eventData.pointerDrag.transform.tag != "Malla")
                Destroy(eventData.pointerDrag);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
        }

    }
}
