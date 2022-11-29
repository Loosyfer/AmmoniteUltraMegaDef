using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject moduleGenPrefab;
    public GameObject[] modulearray;
    public GameObject Info;
    public GameObject neededObjectPrefab;
    public GameObject[] tryArray;
    public GameObject[] tryArrayy;
    public GameObject[] tryArrayyy;
    public GameObject luis;
    public bool activeSelf = true;
    public GameObject memberGenPrefab;
    public GameObject moduleSlotPrefab;
    public ModulesInfo modulesInfo;
    public MemberInfo membersInfo;
    private int loopNumber = 0;
    public List<GameObject> modules = new List<GameObject>();
    public List<GameObject> members = new List<GameObject>();
    public float totalPerformance;

    Unit playerUnit;
    Unit enemyUnit;
    ModuleHUD moduleHUDUnit;
    //ModuleHUD[] moduleHUDArray;
    ModulesInfo moduleInf;
    MemberHUD member;
    ModuleHUD support;
    //ModuleHUD Yrt;

    

    public Text dialogueText;

    //public BattleHUD playerHUD;
    //public BattleHUD enemyHUD;

    public BattleState state;

    public ReadInput script;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        while (activeSelf)
        {

            tryArray = new GameObject[10];
            tryArrayy = new GameObject[10];


            //GameObject moduleGO = Instantiate(moduleGenPrefab);
            //moduleHUDUnit = moduleGO.GetComponent<ModuleHUD>();

            // GameObject randomModule = Instantiate(neededObjectPrefab);
            //moduleInf = randomModule.GetComponent<ModulesInfo>();

            //GameObject randomMember = Instantiate(memberGenPrefab);
            //moduleInf = randomModule.GetComponent<ModulesInfo>();

            // input = BattleSystem.GetComponent<ReadInput>();


            if (loopNumber == 0)
            {

                GameObject playerGO = Instantiate(playerPrefab);
                playerUnit = playerGO.GetComponent<Unit>();

                GameObject enemyGO = Instantiate(enemyPrefab);
                enemyUnit = enemyGO.GetComponent<Unit>();

                GameObject canvas = GameObject.Find("/Malla");

                for (int i = 0; i < 6; i++)
                {
                    GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(480 + i * 200, 565, -1), Quaternion.identity) as GameObject;
                    goo.transform.parent = canvas.transform;

                }

                for (int i = 0; i < 4; i++)
                {
                    GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(680 + i * 200, 679, -1), Quaternion.identity) as GameObject;
                    goo.transform.parent = canvas.transform;
                }

                for (int i = 0; i < 4; i++)
                {
                    GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(680 + i * 200, 451, -1), Quaternion.identity) as GameObject;
                    goo.transform.parent = canvas.transform;
                }


            }

            //InputFunction();

            if (script.inputGiven == true && EventSystem.current.currentSelectedGameObject.name == "SpeModuleGenerator" && script.inputvalue != null)
            {
                GameObject canvas = GameObject.Find("/Malla");
                int k = Random.Range(0, 11);
                script.inputGiven = false;
                int index = int.Parse(script.inputvalue);
                GameObject go = Instantiate(moduleGenPrefab, new Vector3(236, 650, -1), Quaternion.identity) as GameObject;
                go.transform.parent = canvas.transform;
                ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
                modules.Add(go);
                Yrt.nameText.text = modulesInfo.names[index];
                Yrt.detailsText.text = modulesInfo.moduleDetails[index];
                Yrt.type = modulesInfo.moduleType[index];
                Yrt.req = modulesInfo.req[k];
                Yrt.sliderLength = modulesInfo.cooldown[index];
                if (Yrt.sliderLength == 0)
                {
                    Destroy(go.transform.GetChild(1).gameObject);
                    Destroy(go.transform.GetChild(0).gameObject);
                    Destroy(go.transform.GetChild(6).gameObject);
                }
                Image imagen = go.GetComponent<Image>();
                if (Yrt.type == (ModuleType)0) imagen.color = new Color(0, 1f, 0, 1);
                if (Yrt.type == (ModuleType)1) imagen.color = new Color(1, 0, 0, 1);
                if (Yrt.type == (ModuleType)2) imagen.color = new Color(0, 0.6f, 0.839f, 1);
                if (Yrt.type == (ModuleType)4) imagen.color = new Color(1, 0.92f, 0.016f, 1);
                if (Yrt.type == (ModuleType)5) imagen.color = new Color(1, 0.93f, 0, 1);
            }

            if (script.inputGiven == true && EventSystem.current.currentSelectedGameObject.name == "MemberGenerator" && script.inputvalue != null)
            {
                GameObject canvas = GameObject.Find("/Malla");
                int l = Random.Range(0, 5);
                script.inputGiven = false;
                int i = int.Parse(script.inputvalue);
                int index1 = (int) Mathf.Floor(i/1000);
                    int index2 = (int) (i - index1*1000);
                Debug.Log(index1 + index2);
                GameObject go = Instantiate(memberGenPrefab, new Vector3(336, 650, -1), Quaternion.identity) as GameObject;
                go.transform.parent = canvas.transform;
                MemberHUD Yrt = go.GetComponent<MemberHUD>();
                members.Add(go);
                Yrt.nameText.text = membersInfo.names[l];
                Yrt.profDetailsText.text = membersInfo.profDescription[index1];
                Yrt.traitDetailsText.text = membersInfo.tDescription[index2];
                Debug.Log(membersInfo.tDescription[index2]);
                Yrt.trait.text = membersInfo.traitList[index2];
                Yrt.profession = (ProfessionType)index1;
                Yrt.profPrice.text = membersInfo.profPrice[index1].ToString();
                Yrt.traitPrice.text = membersInfo.traitPrice[index2].ToString();
                Yrt.totalPrice.text = (membersInfo.profPrice[index1] + membersInfo.traitPrice[index2]).ToString();
            }

                if (script.inputGiven == true && EventSystem.current.currentSelectedGameObject.name == "ModuleGenerator" && script.inputvalue != null)
            {
                script.inputGiven = false;
                int cyclelenght = int.Parse(script.inputvalue);
                GameObject canvas = GameObject.Find("/Malla");
                for (int i = 0; i < cyclelenght; i++)
                {
                    int j = Random.Range(0, 149);
                    int k = Random.Range(0, 11);
                    GameObject go = Instantiate(moduleGenPrefab, new Vector3(236 + i * 250, 850, -1), Quaternion.identity) as GameObject;
                    go.transform.parent = canvas.transform;
                    tryArray[i] = go;
                    ModuleHUD Yrt = tryArray[i].GetComponent<ModuleHUD>();
                    modules.Add(go);
                    Yrt.nameText.text = modulesInfo.names[j];
                    Yrt.detailsText.text = modulesInfo.moduleDetails[j];
                    Yrt.type = modulesInfo.moduleType[j];
                    Yrt.req = modulesInfo.req[k];
                    Yrt.sliderLength = modulesInfo.cooldown[j];
                    if (Yrt.sliderLength == 0)
                    {
                        Destroy(go.transform.GetChild(1).gameObject);
                        Destroy(go.transform.GetChild(0).gameObject);
                        Destroy(go.transform.GetChild(6).gameObject);
                    }
                    Image imagen = tryArray[i].GetComponent<Image>();
                    if (Yrt.type == (ModuleType)0) imagen.color = new Color(0, 1f, 0, 1);
                    if (Yrt.type == (ModuleType)1) imagen.color = new Color(1, 0, 0, 1);
                    if (Yrt.type == (ModuleType)2) imagen.color = new Color(0, 0.6f, 0.839f, 1);
                    if (Yrt.type == (ModuleType)4) imagen.color = new Color(1, 0.92f, 0.016f, 1);
                    if (Yrt.type == (ModuleType)5) imagen.color = new Color(1, 0.93f, 0, 1);
                }

                for (int i = 0; i < cyclelenght; i++)
                {
                    int j = Random.Range(0, 182);
                    int l = Random.Range(0, 5);
                    int k = Random.Range(0, 12);
                    GameObject go = Instantiate(memberGenPrefab, new Vector3(236 + i * 250, 950, -1), Quaternion.identity) as GameObject;
                    go.transform.parent = canvas.transform;
                    tryArrayy[i] = go;
                    members.Add(go);
                    MemberHUD Yrt = tryArrayy[i].GetComponent<MemberHUD>();
                    Yrt.nameText.text = membersInfo.names[l];
                    Yrt.profDetailsText.text = membersInfo.profDescription[k];
                    Yrt.traitDetailsText.text = membersInfo.tDescription[0];
                    Yrt.trait.text = membersInfo.traitList[j];
                    Yrt.profession = (ProfessionType)k;
                    Yrt.profPrice.text = membersInfo.profPrice[k].ToString();
                    Yrt.traitPrice.text = membersInfo.traitPrice[j].ToString();
                    Yrt.totalPrice.text = (membersInfo.profPrice[k] + membersInfo.traitPrice[j]).ToString();
                    Image imagen = tryArrayy[i].GetComponent<Image>();
                }
            }



            //Yrt[0] = tryArray[0].GetComponent<ModuleHUD>();
            //Yrt[0].nameText.text = moduleInf.names[1];
            //Yrt[0].detailsText.text = moduleInf.description[1];
            //Yrt[0].type = moduleInf.type[1];

            //int random = Random.Range(0, 3);

           //moduleHUDUnit.nameText.text = modulesInfo.names[random];

            //moduleHUDUnit.detailsText.text = modulesInfo.details[random];

            //moduleHUDUnit.type = modulesInfo.type[random];

            //GameObject[] randomSet = new GameObject[10];

            //randomSet[random] = Instantiate(Try[random]);
            //Yrt[random] = randomSet[random].GetComponent<ModulesInfo>();

            //modulearray = new GameObject[3];

            //for (int i = 0; i< 10; ++i)
            //{

            //moduleHUDArrayGO[i] = Instantiate(modulearray[i], new Vector3(336, 366, 0), Quaternion.identity);
            //moduleHUDArray[i] = moduleHUDArrayGO[i].GetComponent<ModuleHUD>();
            //}


            dialogueText.text = "A wild " + enemyUnit.unitName + " approaches.";

            //playerHUD.SetHUD(playerUnit);
            //enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(0);

            /*dialogueText.text = "Get ready for some...";

            yield return new WaitForSeconds(2);

            dialogueText.text = "ACTION!";

            yield return new WaitForSeconds(2);

            */

            state = BattleState.PLAYERTURN;
            PlayerTurn();

            loopNumber++;

            CalculatePerformance();
        }
    }



    /*int InputFunction()
    {
        
    }*/

    void  PlayerTurn()
    {

        dialogueText.text = "Kick that monster's ass";
        return;

    }

    public void TurnButtonClick()
    {
        foreach (GameObject module in modules)
        {
            int length = module.GetComponent<ModuleHUD>().sliderLength;
            bool active = module.GetComponent<ModuleHUD>().cooldownActive;
            if (length == 0 || !active) { }
            else
            {
                float f = (float)1 / length;
                float operation;
                module.transform.GetChild(1).gameObject.GetComponent<Slider>().value -= f;
                module.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                if (module.transform.GetChild(1).gameObject.GetComponent<Slider>().value - f < 0.0001f)
                {
                    module.transform.GetChild(1).gameObject.GetComponent<Slider>().value = 1;
                    module.gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
                }
            }

        }
    }

    public void CalculatePerformance()
    {
        float sum = 0;
        int listLength = members.Count;
        foreach (GameObject member in members)
        {
            sum += (float)(member.transform.GetComponent<MemberHUD>().performance)/ (float)listLength;
        }
        totalPerformance = sum;

    }
}
