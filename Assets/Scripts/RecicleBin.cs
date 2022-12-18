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
                    canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.stackeos[0];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)1)
                {
                    script.stackeos[1]--;
                    canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.stackeos[1];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)2)
                {
                    script.stackeos[2]--;
                    canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.stackeos[2];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)3)
                {
                    script.stackeos[3]--;
                    canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.stackeos[3];
                }
                if (eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)4 || eventData.pointerDrag.GetComponent<ModuleHUD>().type == (ModuleType)5)
                {
                    script.stackeos[4]--;
                    canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.stackeos[4];
                }
            }
            if (eventData.pointerDrag.tag == "Member")
            {
                switch (eventData.pointerDrag.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        script.mStackeos[0]--;
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[0];
                        break;
                    case (ProfessionType)1:
                        script.mStackeos[1]--;
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[1];
                        break;
                    case (ProfessionType)2:
                        script.mStackeos[2]--;
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[2];
                        break;
                    case (ProfessionType)3:
                        script.mStackeos[3]--;
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[3];
                        break;
                    case (ProfessionType)4:
                        script.mStackeos[4]--;
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[4];
                        break;
                    case (ProfessionType)5:
                        script.mStackeos[5]--;
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[5];
                        break;
                    case (ProfessionType)6:
                        script.mStackeos[6]--;
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[6];
                        break;
                    case (ProfessionType)7:
                        script.mStackeos[7]--;
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[7];
                        break;
                    case (ProfessionType)8:
                        script.mStackeos[8]--;
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[8];
                        break;
                    case (ProfessionType)9:
                        script.mStackeos[9]--;
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[9];
                        break;
                    case (ProfessionType)10:
                        script.mStackeos[10]--;
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[10];
                        break;
                    case (ProfessionType)11:
                        script.mStackeos[11]--;
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = "x" + script.mStackeos[11];
                        break;
                }
                script.members.Remove(eventData.pointerDrag);
            }
            Destroy(eventData.pointerDrag);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
        }

    }
}
