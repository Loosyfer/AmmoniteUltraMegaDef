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
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)0)
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
                }
            }
            if (eventData.pointerDrag.tag == "Member")
            {
                switch (eventData.pointerDrag.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        script.mStackeos[0]--;
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[0].ToString();
                        break;
                    case (ProfessionType)1:
                        script.mStackeos[1]--;
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[1].ToString();
                        break;
                    case (ProfessionType)2:
                        script.mStackeos[2]--;
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[2].ToString();
                        break;
                    case (ProfessionType)3:
                        script.mStackeos[3]--;
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[3].ToString();
                        break;
                    case (ProfessionType)4:
                        script.mStackeos[4]--;
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[4].ToString();
                        break;
                    case (ProfessionType)5:
                        script.mStackeos[5]--;
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[5].ToString();
                        break;
                    case (ProfessionType)6:
                        script.mStackeos[6]--;
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[6].ToString();
                        break;
                    case (ProfessionType)7:
                        script.mStackeos[7]--;
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[7].ToString();
                        break;
                    case (ProfessionType)8:
                        script.mStackeos[8]--;
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[8].ToString();
                        break;
                    case (ProfessionType)9:
                        script.mStackeos[9]--;
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[9].ToString();
                        break;
                    case (ProfessionType)10:
                        script.mStackeos[10]--;
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[10].ToString();
                        break;
                    case (ProfessionType)11:
                        script.mStackeos[11]--;
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = script.mStackeos[11].ToString();
                        break;
                }
                script.members.Remove(eventData.pointerDrag);
            }
            Destroy(eventData.pointerDrag);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
        }

    }
}
