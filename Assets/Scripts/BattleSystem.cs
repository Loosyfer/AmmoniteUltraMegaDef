using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;
using BayatGames.SaveGameFree;
using System.Text.RegularExpressions;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject moduleGenPrefab;
    public GameObject[] modulearray;
    public bool activeSelf = true;
    public GameObject memberGenPrefab;
    public GameObject memberBioPrefab;
    public GameObject moduleSlotPrefab;
    public GameObject slotButtonPrefab;
    public GameObject megaHorPrefab;
    public GameObject megaVerPrefab;
    public ModInfo modInfo;
    public ModExcel modExcel;
    public MemberExcel memExcel;
    public MemInfo membersInfo;
    public BioInfo bioInfo;
    public MegamodulesInfo megaInfo;
    private int loopNumber = 0;
    public List<GameObject> modules = new List<GameObject>();
    public List<GameObject> members = new List<GameObject>();
    public List<GameObject> megas = new List<GameObject>();
    public float totalPerformance;
    public GameObject[] slots;
    private GameObject[] buttons;
    private bool destroyedSlots;
    public int[] stackeos = new int[5];
    public int[] mStackeos = new int[14];
    public GameObject stackingFolder;
    public StackingIcons stackingIcons;
    public GameObject turnCounter;
    private int turn;
    public GameObject playerHPBar;
    public GameObject enemyHPBar;
    public GameObject monster;
    public GameObject playerBattleHUD;
    public GameObject rockets;
    public GameObject spark;
    public GameObject currency;
    public GameObject currency2;
    public GameObject fuel;
    public GameObject ReqOnOff;
    public GameObject surprise;
    public GameObject itemSpawner;
    private System.Random randomModules = new System.Random();
    private System.Random randomTraits = new System.Random();
    private System.Random randomProfessions = new System.Random();

    Unit playerUnit;
    Unit enemyUnit;
    ModuleHUD moduleHUDUnit;
    //ModuleHUD[] moduleHUDArray;
    MemberHUD member;
    ModuleHUD support;
    //ModuleHUD Yrt;



    public Text dialogueText;

    //public BattleHUD playerHUD;
    //public BattleHUD enemyHUD;

    public BattleState state;

    void Start()
    {
        //Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        //string[] data = CSVParser.Split(Resources.Load<TextAsset>("Modules/Modules").text);

        string[] modData = Resources.Load<TextAsset>("Excel/Modules").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = (modData.Length / 5) - 1;
        modExcel.myModules.modules = new ModExcel.Module[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            modExcel.myModules.modules[i] = new ModExcel.Module();
            modExcel.myModules.modules[i].name = modData[(5 * (i + 1))];
            modExcel.myModules.modules[i].effect = modData[(5 * (i + 1)) + 1];
            switch (modData[(5 * (i + 1)) + 2])
            {
                case "Organic A":
                    modExcel.myModules.modules[i].type = (ModuleType)0;
                    break;
                case "Offensive":
                    modExcel.myModules.modules[i].type = (ModuleType)1;
                    break;
                case "Defensive":
                    modExcel.myModules.modules[i].type = (ModuleType)2;
                    break;
                case "Scientific":
                    modExcel.myModules.modules[i].type = (ModuleType)3;
                    break;
                case "Normal":
                    modExcel.myModules.modules[i].type = (ModuleType)4;
                    break;
                case "Legendary":
                    modExcel.myModules.modules[i].type = (ModuleType)5;
                    break;
                case "Magic":
                    modExcel.myModules.modules[i].type = (ModuleType)6;
                    break;
            }
            modExcel.myModules.modules[i].requirement = modData[(5 * (i + 1)) + 3];
            if (int.TryParse(modData[(5 * (i + 1)) + 4], out int pri))
                modExcel.myModules.modules[i].price = pri;
        }

        string[] memData = Resources.Load<TextAsset>("Excel/Members").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        tableSize = (memData.Length / 4) - 1;
        memExcel.myMembers.members = new MemberExcel.Member[tableSize];

        for (int j = 0; j < tableSize; j++)
        {
            memExcel.myMembers.members[j] = new MemberExcel.Member();
            memExcel.myMembers.members[j].trait = memData[(4 * (j + 1))];
            memExcel.myMembers.members[j].tEffect = memData[(4 * (j + 1)) + 1];
            switch (memData[(4 * (j + 1)) + 2])
            {

                case "Positive":
                    memExcel.myMembers.members[j].positive = true;
                    memExcel.myMembers.members[j].super = false;
                    memExcel.myMembers.members[j].exclusive = false;
                    memExcel.myMembers.members[j].erudite = false;
                    break;
                case "Erudite":
                    memExcel.myMembers.members[j].positive = false;
                    memExcel.myMembers.members[j].super = false;
                    memExcel.myMembers.members[j].exclusive = false;
                    memExcel.myMembers.members[j].erudite = true;
                    break;
                case "Super":
                    memExcel.myMembers.members[j].positive = false;
                    memExcel.myMembers.members[j].super = true;
                    memExcel.myMembers.members[j].exclusive = false;
                    memExcel.myMembers.members[j].erudite = false;
                    break;
                case "Exclusive":
                    memExcel.myMembers.members[j].positive = false;
                    memExcel.myMembers.members[j].super = false;
                    memExcel.myMembers.members[j].exclusive = true;
                    memExcel.myMembers.members[j].erudite = false;
                    break;
            }
            if (int.TryParse(memData[(4 * (j + 1)) + 3], out int prise))
                memExcel.myMembers.members[j].price = prise;
            else
            {
                Debug.Log(j);
                Debug.Log(memData[(4 * (j + 1)) + 3]);
            }
        }

        stackingIcons.sprites = Resources.LoadAll<Sprite>("Stacking/ButtonsSpriteSheet");

        /*BattleSystem data = new BattleSystem();
        data = SaveGame.Load<BattleSystem>("allData");
        modules = data.modules;
        members = data.members;
        megas = data.megas;*/
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        while (activeSelf)
        {

            if (loopNumber == 0)
            {
                turn = 0;
                StartGame();

            }
            dialogueText.text = "A wild " + enemyUnit.unitName + " approaches.";

            yield return new WaitForSeconds(0);

            state = BattleState.PLAYERTURN;
            PlayerTurn();

            loopNumber++;

            CalculatePerformance();
        }
    }



    /*int InputFunction()
    {
        
    }*/

    void PlayerTurn()
    {

        dialogueText.text = "Kick that monster's ass";
        return;

    }

    void StartGame()
    {
        destroyedSlots = false;

        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<Unit>();

        GameObject canvas = GameObject.Find("/Malla");

        GameObject slotFolder = canvas.transform.GetChild(18).gameObject;
        GameObject slotButtonsFolder = canvas.transform.GetChild(19).gameObject;

        slots = new GameObject[42];
        buttons = new GameObject[42];
        int index = 0;

        for (int j = 0; j < 6; j++)
        {

            for (int i = 0; i < 6; i++)
            {
                GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(745 + (i * 171), 300 + (102 * j), 0), Quaternion.identity) as GameObject;
                goo.transform.parent = slotFolder.transform;
                string name = "";
                name = name + j;
                name = name + i;
                goo.name = name;
                if ((j == 2 || j == 3) && i != 5 && i != 6)
                    goo.transform.GetComponent<ActivateSlot>().activated = true;
                slots[index] = goo;
                index++;
            }
        }

        index = 0;

        for (int j = 0; j < 6; j++)
        {

            for (int i = 0; i < 6; i++)
            {
                GameObject goo = Instantiate(slotButtonPrefab, new Vector3(723 + (i * 27.77f), 18.1f + (22.17f * j), 0), Quaternion.identity) as GameObject;
                goo.transform.parent = slotButtonsFolder.transform;
                string name = "";
                name = name + j;
                name = name + i;
                goo.name = name;
                goo.GetComponent<ButtonFunction>().number = index;
                buttons[index] = goo;
                goo.GetComponent<Button>().onClick.AddListener(() => slots[goo.GetComponent<ButtonFunction>().number].transform.GetComponent<ActivateSlot>().Activate());
                if ((j == 2 || j == 3) && i != 5 && i != 6)
                {
                    goo.transform.GetComponent<ButtonFunction>().activated = true;
                    goo.GetComponent<Image>().color = new Color32(60, 200, 64, 255);
                }
                else
                {
                    goo.transform.GetComponent<ButtonFunction>().activated = false;
                    goo.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
                }
                index++;
            }
        }

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

                float operation;
                module.transform.GetChild(8).gameObject.GetComponent<Slider>().value -= 1;
                module.gameObject.transform.GetChild(8).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                if (module.transform.GetChild(8).gameObject.GetComponent<Slider>().value < 0.0001f)
                {

                    module.transform.GetChild(8).gameObject.GetComponent<Slider>().value = module.transform.GetChild(8).gameObject.GetComponent<Slider>().maxValue;
                    module.gameObject.transform.GetChild(8).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
                }
            }

        }
        foreach (GameObject mega in megas)
        {
            int length = mega.GetComponent<MegaHUD>().sliderLength;
            bool active = mega.GetComponent<MegaHUD>().cooldownActive;
            if (length == 0 || !active) { }
            else
            {

                float operation;
                if (mega.tag == "Mega")
                {
                    mega.transform.GetChild(12).gameObject.GetComponent<Slider>().value -= 1;
                    mega.gameObject.transform.GetChild(12).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    if (mega.transform.GetChild(12).gameObject.GetComponent<Slider>().value < 0.0001f)
                    {

                        mega.transform.GetChild(12).gameObject.GetComponent<Slider>().value = mega.transform.GetChild(12).gameObject.GetComponent<Slider>().maxValue;
                        mega.gameObject.transform.GetChild(12).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
                    }
                }
                else
                {
                    mega.transform.GetChild(10).gameObject.GetComponent<Slider>().value -= 1;
                    mega.gameObject.transform.GetChild(10).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    if (mega.transform.GetChild(10).gameObject.GetComponent<Slider>().value < 0.0001f)
                    {

                        mega.transform.GetChild(10).gameObject.GetComponent<Slider>().value = mega.transform.GetChild(10).gameObject.GetComponent<Slider>().maxValue;
                        mega.gameObject.transform.GetChild(10).GetChild(1).GetChild(0).GetComponent<Image>().color = new Color(1, 0.8031063f, 0.3066038f, 1);
                    }
                }
            }
        }

        turn++;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/Turn");
        turnCounter.transform.GetComponent<TextMeshProUGUI>().text = turn.ToString();
        if ((turn % 2) == 1 && enemyHPBar.GetComponent<Slider>().value != 0)
        {
            playerHPBar.GetComponent<DecreaseHPShip>().ReadStringInput(((monster.GetComponent<MonsterHUD>().dPT) * -1).ToString());
            monster.GetComponent<Animator>().Play("Monster_Attack");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/MonsterAttack");
            List<GameObject> activatedModules = new List<GameObject>();
            for (int j = 0; j < 36; j++)
            {
                if (slots[j].GetComponent<ActivateSlot>().activated && slots[j].GetComponent<ItemSlot>().module != null)
                    activatedModules.Add(slots[j]);
            }
            int i = UnityEngine.Random.Range(0, activatedModules.Count);
            Vector3 pos = activatedModules[i].transform.position;
            StartCoroutine(PlayExplosion(pos + new Vector3(-25, 0, 0)));
            StartCoroutine(AttackModule(activatedModules[i]));
        }
        if ((turn % 2) == 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Effects/ShipAttack");
            enemyHPBar.GetComponent<DecreaseHP>().ReadStringInput(((playerBattleHUD.GetComponent<TotalDamage>().sum) * -1).ToString());
            if (enemyHPBar.GetComponent<Slider>().value == 0)
                monster.GetComponent<Animator>().Play("Monster_Die");
            else
                monster.GetComponent<Animator>().Play("Monster_Flinch");
            rockets.transform.GetChild(0).GetComponent<Animator>().Play("AA_0x3");
        }

    }

    IEnumerator PlayExplosion(Vector3 pos)
    {
        yield return new WaitForSeconds(0.1f);
        spark.transform.position = pos;
        spark.GetComponent<VideoPlayer>().Play();
    }

    public void CalculatePerformance()
    {
        float sum = 0;
        int listLength = members.Count;
        foreach (GameObject member in members)
        {
            sum += (float)(member.transform.GetComponent<MemberHUD>().performance) / (float)listLength;
        }
        totalPerformance = sum;

    }

    public void GenerateModules(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        int k = UnityEngine.Random.Range(0, 13);
        if (!int.TryParse(s, out int index))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (index > 208)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = Instantiate(moduleGenPrefab, new Vector3(908, 960, 0), Quaternion.identity) as GameObject;
        go.transform.parent = modulesFolder.transform;
        ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
        modules.Add(go);
        Yrt.nameText.text = modInfo.names[index];
        Yrt.detailsText.text = modInfo.moduleDetails[index];
        Yrt.price = modInfo.modulePrice[index];
        Yrt.type = modInfo.moduleType[index];
        Yrt.id = index;
        switch (Yrt.type)
        {
            case (ModuleType)0:
                Yrt.typeDetails.text = modInfo.typeStacking[0];
                break;
            case (ModuleType)1:
                Yrt.typeDetails.text = modInfo.typeStacking[1];
                break;
            case (ModuleType)2:
                Yrt.typeDetails.text = modInfo.typeStacking[2];
                break;
            case (ModuleType)3:
                Yrt.typeDetails.text = modInfo.typeStacking[3];
                break;
            case (ModuleType)4:
                Yrt.typeDetails.text = modInfo.typeStacking[4];
                break;
            case (ModuleType)5:
                Yrt.typeDetails.text = modInfo.typeStacking[5];
                break;
        }
        switch (modInfo.req[index])
        {
            case "0":
                Yrt.req.text = "No Requirement";
                Yrt.reqType = 0;
                break;
            case "1":
                Yrt.req.text = modInfo.randomReq[k].ToString();
                Yrt.reqType = 1;
                switch (k)
                {
                    case 0:
                        go.transform.GetChild(11).GetChild(9).gameObject.SetActive(true);
                        Yrt.reqId = 0;
                        break;
                    case 1:
                        go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                        Yrt.reqId = 1;
                        break;
                    case 2:
                        go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                        Yrt.reqId = 2;
                        break;
                    case 3:
                        go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                        Yrt.reqId = 3;
                        break;
                    case 4:
                        go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                        Yrt.reqId = 4;
                        break;
                    case 5:
                        go.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                        Yrt.reqId = 5;
                        break;
                    case 6:
                        go.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                        Yrt.reqId = 6;
                        break;
                    case 7:
                        go.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                        Yrt.reqId = 7;
                        break;
                    case 8:
                        go.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                        Yrt.reqId = 8;
                        break;
                    case 9:
                        go.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                        Yrt.reqId = 9;
                        break;
                    case 10:
                        go.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                        Yrt.reqId = 10;
                        break;
                    case 11:
                        go.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                        Yrt.reqId = 11;
                        break;
                    case 12:
                        go.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                        Yrt.reqId = 12;
                        break;
                }
                break;
            default:
                Yrt.req.text = modInfo.req[index];
                Yrt.reqType = 2;
                go.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                break;
        }
        /*int m = System.Random.Range(0, 2);
        if (m == 0)
        {
            float l = System.Random.Range(0f, 100f);
            if (l <= 3.25f)
                go.transform.GetChild(12).GetChild(0).gameObject.SetActive(true);
            if (l <= 6.5f && l > 3.25f)
                go.transform.GetChild(12).GetChild(1).gameObject.SetActive(true);
            if (l <= 9.75f && l > 6.5f)
                go.transform.GetChild(12).GetChild(2).gameObject.SetActive(true);
            if (l <= 13f && l > 9.75f)
                go.transform.GetChild(12).GetChild(3).gameObject.SetActive(true);
            if (l <= 16.25f && l > 13f)
                go.transform.GetChild(12).GetChild(4).gameObject.SetActive(true);
            if (l <= 19.5f && l > 16.25f)
                go.transform.GetChild(12).GetChild(5).gameObject.SetActive(true);
            if (l <= 22.75f && l > 19.5f)
                go.transform.GetChild(12).GetChild(6).gameObject.SetActive(true);
            if (l <= 26f && l > 22.75f)
                go.transform.GetChild(12).GetChild(7).gameObject.SetActive(true);
            if (l <= 29.25f && l > 26f)
                go.transform.GetChild(12).GetChild(8).gameObject.SetActive(true);
            if (l <= 32.5f && l > 29.25f)
                go.transform.GetChild(12).GetChild(9).gameObject.SetActive(true);
            if (l <= 35.75f && l > 32.5f)
                go.transform.GetChild(12).GetChild(10).gameObject.SetActive(true);
            if (l <= 39 && l > 35.75f)
                go.transform.GetChild(12).GetChild(11).gameObject.SetActive(true);
            if (l <= 42 && l > 39f)
                go.transform.GetChild(12).GetChild(12).gameObject.SetActive(true);
            if (l <= 45 && l > 42f)
                go.transform.GetChild(12).GetChild(13).gameObject.SetActive(true);
            if (l <= 48 && l > 45f)
                go.transform.GetChild(12).GetChild(14).gameObject.SetActive(true);
            if (l <= 51 && l > 48f)
                go.transform.GetChild(12).GetChild(15).gameObject.SetActive(true);
            if (l <= 54 && l > 51f)
                go.transform.GetChild(12).GetChild(16).gameObject.SetActive(true);
            if (l <= 57 && l > 54f)
                go.transform.GetChild(12).GetChild(17).gameObject.SetActive(true);
            if (l <= 60.25f && l > 57f)
                go.transform.GetChild(12).GetChild(18).gameObject.SetActive(true);
            if (l <= 63.5f && l > 60.25f)
                go.transform.GetChild(12).GetChild(19).gameObject.SetActive(true);
            if (l <= 66.5 && l > 63.5f)
                go.transform.GetChild(12).GetChild(20).gameObject.SetActive(true);
            if (l <= 69.5f && l > 66.5f)
                go.transform.GetChild(12).GetChild(21).gameObject.SetActive(true);
            if (l <= 75.5 && l > 69.5f)
                go.transform.GetChild(12).GetChild(22).gameObject.SetActive(true);
            if (l <= 81.5f && l > 75.5f)
                go.transform.GetChild(12).GetChild(23).gameObject.SetActive(true);
            if (l <= 84.5 && l > 81.5f)
                go.transform.GetChild(12).GetChild(24).gameObject.SetActive(true);
            if (l <= 87.5f && l > 84.5f)
                go.transform.GetChild(12).GetChild(25).gameObject.SetActive(true);
            if (l <= 90.5 && l > 87.5)
                go.transform.GetChild(12).GetChild(26).gameObject.SetActive(true);
            if (l <= 93.5 && l > 90.5f)
                go.transform.GetChild(12).GetChild(27).gameObject.SetActive(true);
            if (l <= 96.75 && l > 93.5f)
                go.transform.GetChild(12).GetChild(28).gameObject.SetActive(true);
            if (l > 96.75f)
                go.transform.GetChild(12).GetChild(29).gameObject.SetActive(true);
        }*/

        Yrt.sliderLength = modInfo.cooldown[index];
        if (Yrt.sliderLength == 0)
        {
            Destroy(go.transform.GetChild(8).gameObject);
        }
        else
        {
            go.transform.GetChild(8).GetComponent<Slider>().maxValue = Yrt.sliderLength;
            go.transform.GetChild(8).GetComponent<Slider>().value = Yrt.sliderLength;
        }
        Image imagen = go.transform.GetComponent<Image>();
        if (Yrt.type == (ModuleType)0)
        {
            imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
            /*stackeos[0]++;
            canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
            if (stackeos[0] < 4)
                stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
            else
                stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];*/
        }
        if (Yrt.type == (ModuleType)1)
        {
            imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
            /*stackeos[1]++;
            canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = stackeos[1].ToString();
            if (stackeos[1] == 1)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
            if (stackeos[1] == 2 || stackeos[1] == 3)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
            if (stackeos[1] == 4 || stackeos[1] == 5)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
            if (stackeos[1] > 5)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];*/
        }
        if (Yrt.type == (ModuleType)2)
        {
            imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);
            /*stackeos[2]++;
            canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = stackeos[2].ToString();
            if (stackeos[2] == 1)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
            if (stackeos[2] == 2 || stackeos[1] == 3)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
            if (stackeos[2] == 4 || stackeos[1] == 5)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
            if (stackeos[2] > 5)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];*/
        }
        if (Yrt.type == (ModuleType)3)
        {
            imagen.color = new Color(0.7f, 0.7f, 0.7f, 1);
            /*stackeos[3]++;
            canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = stackeos[3].ToString();
            if (stackeos[3] < 4)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
            if (stackeos[3] > 3 && stackeos[3] < 8)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
            if (stackeos[3] > 7)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];*/

        }
        if (Yrt.type == (ModuleType)4)
        {
            imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);
            /*stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
            if (stackeos[4] < 6)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
            if (stackeos[4] > 5 && stackeos[4] < 10)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
            if (stackeos[4] > 9)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
        }
        if (Yrt.type == (ModuleType)5)
        {
            imagen.color = new Color(0.9843f, 1, 0.2196f, 1);
            /*stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
            if (stackeos[4] < 6)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
            if (stackeos[4] > 5 && stackeos[4] < 10)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
            if (stackeos[4] > 9)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
        }
        int n = UnityEngine.Random.Range(0, 100);
        Yrt.sEffectorDefect = 0;
        if (n < 60)
        {
            Sprite[] all = Resources.LoadAll<Sprite>("Effects/SideEffects");
            int l = UnityEngine.Random.Range(0, all.Length);
            Yrt.sideEffectId = l;
            Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
            int p = UnityEngine.Random.Range(0, 4);
            switch (p)
            {
                case 0:
                    Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 0;
                    break;
                case 1:
                    Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 1;
                    break;
                case 2:
                    Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 2;
                    break;
                case 3:
                    Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 3;
                    break;
            }
        }
        if (n >= 90)
        {
            Sprite[] all = Resources.LoadAll<Sprite>("Effects/Defects");
            int l = UnityEngine.Random.Range(0, all.Length);
            Yrt.sideEffectId = l;
            Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
            int p = UnityEngine.Random.Range(0, 4);
            switch (p)
            {
                case 0:
                    Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 0;
                    break;
                case 1:
                    Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 1;
                    break;
                case 2:
                    Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 2;
                    break;
                case 3:
                    Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 3;
                    break;
            }
        }
    }

    public void GenerateModules2(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        int k = UnityEngine.Random.Range(0, 12);
        while(k==2)
            k = UnityEngine.Random.Range(0, 12);
        if (!int.TryParse(s, out int index))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (index > 250)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = Instantiate(moduleGenPrefab, new Vector3(908, 960, 0), Quaternion.identity) as GameObject;
        go.transform.parent = modulesFolder.transform;
        ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
        modules.Add(go);
        Yrt.nameText.text = modExcel.myModules.modules[index].name;
        Yrt.detailsText.text = modExcel.myModules.modules[index].effect;
        Yrt.detailsText.text = Yrt.detailsText.text.Replace("*", ",");
        Yrt.detailsText.text = Yrt.detailsText.text.Replace("&quote;", "");
        Yrt.price = modExcel.myModules.modules[index].price;
        Yrt.type = modExcel.myModules.modules[index].type;
        Yrt.id = index;
        Yrt.reqActive = true;
        switch (Yrt.type)
        {
            case (ModuleType)0:
                Yrt.typeDetails.text = modInfo.typeStacking[0];
                break;
            case (ModuleType)1:
                Yrt.typeDetails.text = modInfo.typeStacking[1];
                break;
            case (ModuleType)2:
                Yrt.typeDetails.text = modInfo.typeStacking[2];
                break;
            case (ModuleType)3:
                Yrt.typeDetails.text = modInfo.typeStacking[3];
                break;
            case (ModuleType)4:
                Yrt.typeDetails.text = modInfo.typeStacking[4];
                break;
            case (ModuleType)5:
                Yrt.typeDetails.text = modInfo.typeStacking[5];
                break;
        }

        int u = UnityEngine.Random.Range(0, 100);
        int r;
        switch (u)
        {
            case int h when (h >= 0 && h < 40):
                r = UnityEngine.Random.Range(0, 6);
                go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                Yrt.energy = r;
                break;
            case int h when (h >= 40 && h < 70):
                r = UnityEngine.Random.Range(6, 10);
                go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                Yrt.energy = r;
                break;
            case 70:
                go.transform.GetChild(23).GetChild(10).gameObject.SetActive(true);
                Yrt.energy = 10;
                break;
            case int h when (h >= 71 && h < 73):
                r = UnityEngine.Random.Range(11, 15);
                go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                Yrt.energy = r;
                break;
            case int h when (h >= 73 && h <= 87):
                int z = UnityEngine.Random.Range(0, 3);
                switch (z)
                {
                    case 0:
                        r = 20;
                        go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                        Yrt.energy = r;
                        break;
                    case 1:
                        r = 21;
                        go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                        Yrt.energy = r;
                        break;
                    case 2:
                        r = 24;
                        go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                        Yrt.energy = r;
                        break;
                }
                break;
            case int h when (h >= 88 && h <= 92):
                r = UnityEngine.Random.Range(22, 24);
                go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                Yrt.energy = r;
                break;
            case 93:
                go.transform.GetChild(23).GetChild(31).gameObject.SetActive(true);
                Yrt.energy = 31;
                break;
            case int h when (h >= 94):
                r = UnityEngine.Random.Range(32, 44);
                go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                Yrt.energy = r;
                break;
        }

        if (ReqOnOff.transform.GetComponent<RequirementsButton>().state)
        {
            Yrt.reqActive = true;
            switch (modExcel.myModules.modules[index].requirement)
            {
                case "":
                    Yrt.req.text = modInfo.randomReq[k].ToString();
                    Yrt.reqType = 1;
                    switch (k)
                    {
                        case 0:
                            go.transform.GetChild(11).GetChild(9).gameObject.SetActive(true);
                            Yrt.reqId = 0;
                            break;
                        case int h when (h == 1 || h == 10):
                            int l = UnityEngine.Random.Range(0, 4);
                            switch (l)
                            {
                                case 0:
                                    go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                                    Yrt.reqId = 1;
                                    break;
                                case 1:
                                    go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                                    Yrt.reqId = 2;
                                    break;
                                case 2:
                                    go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                                    Yrt.reqId = 3;
                                    break;
                                case 3:
                                    go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                                    Yrt.reqId = 4;
                                    break;
                            }
                            break;
                        case 2:
                            //go.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                            Yrt.reqId = 5;
                            break;
                        case 3:
                            go.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                            Yrt.reqId = 6;
                            break;
                        case 4:
                                go.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                                Yrt.reqId = 7;
                            break;
                        case 5:
                            int p = UnityEngine.Random.Range(0, 4);
                            switch (p)
                            {
                                case 0:
                                    go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                                    Yrt.reqId = 1;
                                    break;
                                case 1:
                                    go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                                    Yrt.reqId = 2;
                                    break;
                                case 2:
                                    go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                                    Yrt.reqId = 3;
                                    break;
                                case 3:
                                    go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                                    Yrt.reqId = 4;
                                    break;
                            }
                            break;
                        case 6:
                            go.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                            Yrt.reqId = 9;
                            break;
                        case 7:
                            go.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                            Yrt.reqId = 10;
                            break;
                        case 8:
                            go.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                            Yrt.reqId = 11;
                            break;
                        case 9:
                            go.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                            Yrt.reqId = 12;
                            break;
                        case 11:
                            go.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                            Yrt.reqId = 8;
                            break;
                    }
                    break;
                default:
                    Yrt.req.text = modExcel.myModules.modules[index].requirement;
                    Yrt.reqType = 2;
                    go.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                    break;
            }
        }
        /*int m = System.Random.Range(0, 2);
        if (m == 0)
        {
            float l = System.Random.Range(0f, 100f);
            if (l <= 3.25f)
                go.transform.GetChild(12).GetChild(0).gameObject.SetActive(true);
            if (l <= 6.5f && l > 3.25f)
                go.transform.GetChild(12).GetChild(1).gameObject.SetActive(true);
            if (l <= 9.75f && l > 6.5f)
                go.transform.GetChild(12).GetChild(2).gameObject.SetActive(true);
            if (l <= 13f && l > 9.75f)
                go.transform.GetChild(12).GetChild(3).gameObject.SetActive(true);
            if (l <= 16.25f && l > 13f)
                go.transform.GetChild(12).GetChild(4).gameObject.SetActive(true);
            if (l <= 19.5f && l > 16.25f)
                go.transform.GetChild(12).GetChild(5).gameObject.SetActive(true);
            if (l <= 22.75f && l > 19.5f)
                go.transform.GetChild(12).GetChild(6).gameObject.SetActive(true);
            if (l <= 26f && l > 22.75f)
                go.transform.GetChild(12).GetChild(7).gameObject.SetActive(true);
            if (l <= 29.25f && l > 26f)
                go.transform.GetChild(12).GetChild(8).gameObject.SetActive(true);
            if (l <= 32.5f && l > 29.25f)
                go.transform.GetChild(12).GetChild(9).gameObject.SetActive(true);
            if (l <= 35.75f && l > 32.5f)
                go.transform.GetChild(12).GetChild(10).gameObject.SetActive(true);
            if (l <= 39 && l > 35.75f)
                go.transform.GetChild(12).GetChild(11).gameObject.SetActive(true);
            if (l <= 42 && l > 39f)
                go.transform.GetChild(12).GetChild(12).gameObject.SetActive(true);
            if (l <= 45 && l > 42f)
                go.transform.GetChild(12).GetChild(13).gameObject.SetActive(true);
            if (l <= 48 && l > 45f)
                go.transform.GetChild(12).GetChild(14).gameObject.SetActive(true);
            if (l <= 51 && l > 48f)
                go.transform.GetChild(12).GetChild(15).gameObject.SetActive(true);
            if (l <= 54 && l > 51f)
                go.transform.GetChild(12).GetChild(16).gameObject.SetActive(true);
            if (l <= 57 && l > 54f)
                go.transform.GetChild(12).GetChild(17).gameObject.SetActive(true);
            if (l <= 60.25f && l > 57f)
                go.transform.GetChild(12).GetChild(18).gameObject.SetActive(true);
            if (l <= 63.5f && l > 60.25f)
                go.transform.GetChild(12).GetChild(19).gameObject.SetActive(true);
            if (l <= 66.5 && l > 63.5f)
                go.transform.GetChild(12).GetChild(20).gameObject.SetActive(true);
            if (l <= 69.5f && l > 66.5f)
                go.transform.GetChild(12).GetChild(21).gameObject.SetActive(true);
            if (l <= 75.5 && l > 69.5f)
                go.transform.GetChild(12).GetChild(22).gameObject.SetActive(true);
            if (l <= 81.5f && l > 75.5f)
                go.transform.GetChild(12).GetChild(23).gameObject.SetActive(true);
            if (l <= 84.5 && l > 81.5f)
                go.transform.GetChild(12).GetChild(24).gameObject.SetActive(true);
            if (l <= 87.5f && l > 84.5f)
                go.transform.GetChild(12).GetChild(25).gameObject.SetActive(true);
            if (l <= 90.5 && l > 87.5)
                go.transform.GetChild(12).GetChild(26).gameObject.SetActive(true);
            if (l <= 93.5 && l > 90.5f)
                go.transform.GetChild(12).GetChild(27).gameObject.SetActive(true);
            if (l <= 96.75 && l > 93.5f)
                go.transform.GetChild(12).GetChild(28).gameObject.SetActive(true);
            if (l > 96.75f)
                go.transform.GetChild(12).GetChild(29).gameObject.SetActive(true);
        }*/


        Destroy(go.transform.GetChild(8).gameObject);
        Image imagen = go.transform.GetComponent<Image>();
        if (Yrt.type == (ModuleType)0)
        {
            imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
            /*stackeos[0]++;
            canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
            if (stackeos[0] < 4)
                stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
            else
                stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];*/
        }
        if (Yrt.type == (ModuleType)1)
        {
            imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
            /*stackeos[1]++;
            canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = stackeos[1].ToString();
            if (stackeos[1] == 1)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
            if (stackeos[1] == 2 || stackeos[1] == 3)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
            if (stackeos[1] == 4 || stackeos[1] == 5)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
            if (stackeos[1] > 5)
                stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];*/
        }
        if (Yrt.type == (ModuleType)2)
        {
            imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);
            /*stackeos[2]++;
            canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = stackeos[2].ToString();
            if (stackeos[2] == 1)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
            if (stackeos[2] == 2 || stackeos[1] == 3)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
            if (stackeos[2] == 4 || stackeos[1] == 5)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
            if (stackeos[2] > 5)
                stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];*/
        }
        if (Yrt.type == (ModuleType)3)
        {
            imagen.color = new Color(0.7f, 0.7f, 0.7f, 1);
            /*stackeos[3]++;
            canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = stackeos[3].ToString();
            if (stackeos[3] < 4)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
            if (stackeos[3] > 3 && stackeos[3] < 8)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
            if (stackeos[3] > 7)
                stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];*/

        }
        if (Yrt.type == (ModuleType)4)
        {
            imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);
            /*stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
            if (stackeos[4] < 6)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
            if (stackeos[4] > 5 && stackeos[4] < 10)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
            if (stackeos[4] > 9)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
        }
        if (Yrt.type == (ModuleType)5)
        {
            imagen.color = new Color(0, 1, 1, 1);
            /*stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
            if (stackeos[4] < 6)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
            if (stackeos[4] > 5 && stackeos[4] < 10)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
            if (stackeos[4] > 9)
                stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
        }
        int n = UnityEngine.Random.Range(0, 100);
        Yrt.sEffectorDefect = 0;
        if (n < 60)
        {
            Sprite[] all = Resources.LoadAll<Sprite>("Effects/SideEffects");
            int l = UnityEngine.Random.Range(0, all.Length);
            Yrt.sideEffectId = l;
            Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
            int p = UnityEngine.Random.Range(0, 4);
            switch (p)
            {
                case 0:
                    Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 0;
                    break;
                case 1:
                    Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 1;
                    break;
                case 2:
                    Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 2;
                    break;
                case 3:
                    Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                    Yrt.sEffectorDefect = 1;
                    Yrt.sEffectSide = 3;
                    break;
            }
        }
        if (n >= 90)
        {
            Sprite[] all = Resources.LoadAll<Sprite>("Effects/Defects");
            int l = UnityEngine.Random.Range(0, all.Length);
            Yrt.sideEffectId = l;
            Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
            int p = UnityEngine.Random.Range(0, 4);
            switch (p)
            {
                case 0:
                    Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 0;
                    break;
                case 1:
                    Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 1;
                    break;
                case 2:
                    Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 2;
                    break;
                case 3:
                    Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                    Yrt.sEffectorDefect = 2;
                    Yrt.sEffectSide = 3;
                    break;
            }
        }
    }

    public void GenerateMembers(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
        int l = UnityEngine.Random.Range(0, membersInfo.names.Length);
        if (!int.TryParse(s, out int i))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }
        int index1 = (int)Mathf.Floor(i / 1000);
        int index2 = (int)(i - index1 * 1000);
        Debug.Log(index1 + index2);
        GameObject go = Instantiate(memberGenPrefab, new Vector3(820, 1025, 0), Quaternion.identity) as GameObject;
        go.transform.parent = membersFolder.transform;
        MemberHUD Yrt = go.GetComponent<MemberHUD>();
        members.Add(go);
        Yrt.nameText.text = membersInfo.names[l];
        Yrt.profDetailsText.text = (ProfessionType)index1 + " = " + membersInfo.profDescription[index1];
        Yrt.traitDetailsText.text = membersInfo.traitList[index2] + " = " + membersInfo.tDescription[index2];
        Yrt.trait.text = membersInfo.traitList[index2];
        Yrt.profession = (ProfessionType)index1;
        Yrt.profPrice.text = membersInfo.profPrice[index1].ToString();
        Yrt.traitPrice.text = Yrt.trait.text + "(" + membersInfo.traitPrice[index2].ToString() + ") + " + Yrt.profession + "(" + Yrt.profPrice.text + ") = " + (membersInfo.profPrice[index1] + membersInfo.traitPrice[index2]).ToString();
        Yrt.totalPrice.text = (membersInfo.profPrice[index1] + membersInfo.traitPrice[index2]).ToString();
        float m = UnityEngine.Random.Range(0f, 100f);
        if (m < 70f)
            Yrt.performance = 40;
        if (m >= 70f && m < 93f)
            Yrt.performance = 45;
        if (m >= 93f)
            Yrt.performance = 50;
        /*mStackeos[index1]++;
        canvas.transform.GetChild(30).GetChild(index1 + 5).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[index1].ToString();*/

        /*switch (index1)
        {
            case 0:
                if (mStackeos[0] > 0 && mStackeos[0] < 3)
                    stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                if (mStackeos[0] > 2 && mStackeos[0] < 6)
                    stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                if (mStackeos[0] > 5)
                    stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                break;
            case 1:
                if (mStackeos[1] > 0 && mStackeos[1] < 3)
                    stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                if (mStackeos[1] > 2 && mStackeos[1] < 6)
                    stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                if (mStackeos[1] > 5)
                    stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                break;
            case 2:
                if (mStackeos[2] > 0 && mStackeos[2] < 4)
                    stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                if (mStackeos[2] > 3 && mStackeos[2] < 8)
                    stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                if (mStackeos[2] > 7)
                    stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                break;
            case 3:
                if (mStackeos[3] > 0 && mStackeos[3] < 3)
                    stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                if (mStackeos[3] > 2 && mStackeos[3] < 6)
                    stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                if (mStackeos[3] > 5)
                    stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                break;
            case 4:
                if (mStackeos[4] > 0 && mStackeos[4] < 3)
                    stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                if (mStackeos[4] > 2 && mStackeos[4] < 6)
                    stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                if (mStackeos[4] > 5)
                    stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                break;
            case 5:
                if (mStackeos[5] > 0 && mStackeos[5] < 4)
                    stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                if (mStackeos[5] > 3 && mStackeos[5] < 6)
                    stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[22];
                if (mStackeos[5] > 5)
                    stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[23];
                break;
            case 6:
                if (mStackeos[6] > 0 && mStackeos[6] < 3)
                    stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                if (mStackeos[6] > 2 && mStackeos[6] < 6)
                    stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                if (mStackeos[6] > 5)
                    stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                break;
            case 7:
                if (mStackeos[7] > 0 && mStackeos[7] < 2)
                    stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[29];
                if (mStackeos[7] > 1 && mStackeos[7] < 4)
                    stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[30];
                if (mStackeos[7] > 3)
                    stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[31];
                break;
            case 8:
                if (mStackeos[8] > 0 && mStackeos[8] < 3)
                    stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                if (mStackeos[8] > 2 && mStackeos[8] < 6)
                    stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                if (mStackeos[8] > 5)
                    stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                break;
            case 9:
                if (mStackeos[9] > 0 && mStackeos[9] < 3)
                    stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                if (mStackeos[9] > 2 && mStackeos[9] < 6)
                    stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                if (mStackeos[9] > 5)
                    stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                break;
            case 10:
                if (mStackeos[10] > 0 && mStackeos[10] < 4)
                    stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[41];
                if (mStackeos[10] > 3)
                    stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[43];
                break;
            case 11:
                stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[47];
                break;
        }*/
    }

    public void GenerateMembers2(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
        int l = UnityEngine.Random.Range(0, membersInfo.names.Length);
        if (!int.TryParse(s, out int i))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }
        int index1 = (int)Mathf.Floor(i / 1000);
        int index2 = (int)(i - index1 * 1000);
        Debug.Log(index1 + index2);
        GameObject go = Instantiate(memberGenPrefab, new Vector3(820, 1025, 0), Quaternion.identity) as GameObject;
        go.transform.parent = membersFolder.transform;
        MemberHUD Yrt = go.GetComponent<MemberHUD>();
        members.Add(go);
        Yrt.nameText.text = membersInfo.names[l];
        Yrt.profDetailsText.text = (ProfessionType)index1 + " = " + membersInfo.profDescription[index1];
        Yrt.traitDetailsText.text = memExcel.myMembers.members[index2].trait + " = " + memExcel.myMembers.members[index2].tEffect;
        Yrt.traitDetailsText.text = Yrt.traitDetailsText.text.Replace("*", ",");
        Yrt.trait.text = memExcel.myMembers.members[index2].trait;
        Yrt.profession = (ProfessionType)index1;
        Yrt.profPrice.text = membersInfo.profPrice[index1].ToString();
        Yrt.traitPrice.text = Yrt.trait.text + "(" + memExcel.myMembers.members[index2].price.ToString() + ") + " + Yrt.profession + "(" + Yrt.profPrice.text + ") = " + (membersInfo.profPrice[index1] + memExcel.myMembers.members[index2].price).ToString();
        Yrt.totalPrice.text = (membersInfo.profPrice[index1] + memExcel.myMembers.members[index2].price).ToString();
        Yrt.id = index2;
        Yrt.professionId = index1;
        float m = UnityEngine.Random.Range(0f, 100f);
        if (m < 70f)
            Yrt.performance = 40;
        if (m >= 70f && m < 93f)
            Yrt.performance = 45;
        if (m >= 93f)
            Yrt.performance = 50;

    }

    public void Shop()
    {
        int l = UnityEngine.Random.Range(0, 100);
        switch (l)
        {
            case int n when (n <= 75):
                Generate("5");
                break;
            case int n when (n > 75 && n <= 90):
                Generate("4");
                break;
            default:
                Generate("6");
                break;
        }
        l = UnityEngine.Random.Range(0, 100);
        if (l <= 10)
            surprise.gameObject.SetActive(true);
        l = UnityEngine.Random.Range(0, 100);
        if (l <= 25)
            itemSpawner.gameObject.GetComponent<ItemSpawner>().SpawnObject();
    }

    public void Generate(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        if (!int.TryParse(s, out int cyclelength))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (cyclelength > 6)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
        for (int i = 0; i < cyclelength; i++)
        {
            int j = randomModules.Next(0, 208);
            int k = UnityEngine.Random.Range(0, 12);
            while (k == 2)
                k = UnityEngine.Random.Range(0, 12);
            while (modExcel.myModules.modules[j].type == (ModuleType)5 || modExcel.myModules.modules[j].type == (ModuleType)6)
                j = randomModules.Next(0, 208);
            GameObject go = Instantiate(moduleGenPrefab, new Vector3(272 + i * 163, 1016, 0), Quaternion.identity) as GameObject;
            go.transform.parent = modulesFolder.transform;
            ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
            modules.Add(go);
            Yrt.nameText.text = modExcel.myModules.modules[j].name;
            Yrt.detailsText.text = modExcel.myModules.modules[j].effect;
            Yrt.detailsText.text = Yrt.detailsText.text.Replace("*", ",");
            Yrt.detailsText.text = Yrt.detailsText.text.Replace("&quote;", "");
            Yrt.price = modExcel.myModules.modules[j].price;
            Yrt.type = modExcel.myModules.modules[j].type;
            Yrt.id = j;
            switch (Yrt.type)
            {
                case (ModuleType)0:
                    Yrt.typeDetails.text = modInfo.typeStacking[0];
                    break;
                case (ModuleType)1:
                    Yrt.typeDetails.text = modInfo.typeStacking[1];
                    break;
                case (ModuleType)2:
                    Yrt.typeDetails.text = modInfo.typeStacking[2];
                    break;
                case (ModuleType)3:
                    Yrt.typeDetails.text = modInfo.typeStacking[3];
                    break;
                case (ModuleType)4:
                    Yrt.typeDetails.text = modInfo.typeStacking[4];
                    break;
                case (ModuleType)5:
                    Yrt.typeDetails.text = modInfo.typeStacking[5];
                    break;
            }

            int u = UnityEngine.Random.Range(0, 100);
            int r;
            switch (u)
            {
                case int h when (h >= 0 && h < 40):
                    r = UnityEngine.Random.Range(0, 6);
                    go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                    Yrt.energy = r;
                    break;
                case int h when (h >= 40 && h < 70):
                    r = UnityEngine.Random.Range(6, 10);
                    go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                    Yrt.energy = r;
                    break;
                case 70:
                    go.transform.GetChild(23).GetChild(10).gameObject.SetActive(true);
                    Yrt.energy = 10;
                    break;
                case int h when (h >= 71 && h < 73):
                    r = UnityEngine.Random.Range(11, 15);
                    go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                    Yrt.energy = r;
                    break;
                case int h when (h >= 73 && h <= 87):
                    int z = UnityEngine.Random.Range(0, 3);
                    switch (z)
                    {
                        case 0:
                            r = 20;
                            go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                            Yrt.energy = r;
                            break;
                        case 1:
                            r = 21;
                            go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                            Yrt.energy = r;
                            break;
                        case 2:
                            r = 24;
                            go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                            Yrt.energy = r;
                            break;
                    }
                    break;
                case int h when (h >= 88 && h <= 92):
                    r = UnityEngine.Random.Range(22, 24);
                    go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                    Yrt.energy = r;
                    break;
                case 93:
                    go.transform.GetChild(23).GetChild(31).gameObject.SetActive(true);
                    Yrt.energy = 31;
                    break;
                case int h when (h >= 94):
                    r = UnityEngine.Random.Range(32, 44);
                    go.transform.GetChild(23).GetChild(r).gameObject.SetActive(true);
                    Yrt.energy = r;
                    break;
            }
            if (ReqOnOff.transform.GetComponent<RequirementsButton>().state)
            {
                Yrt.reqActive = true;
                switch (modExcel.myModules.modules[j].requirement)
                {
                    case "":
                        Yrt.req.text = modInfo.randomReq[k].ToString();
                        Yrt.reqType = 1;
                        switch (k)
                        {
                            case 0:
                                go.transform.GetChild(11).GetChild(9).gameObject.SetActive(true);
                                Yrt.reqId = 0;
                                break;
                            case int p when (p == 1 || p == 10):
                                int l = UnityEngine.Random.Range(0, 4);
                                switch (l)
                                {
                                    case 0:
                                        go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                                        Yrt.reqId = 1;
                                        break;
                                    case 1:
                                        go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                                        Yrt.reqId = 2;
                                        break;
                                    case 2:
                                        go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                                        Yrt.reqId = 3;
                                        break;
                                    case 3:
                                        go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                                        Yrt.reqId = 4;
                                        break;
                                }
                                break;
                            case 2:
                                //go.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                                Yrt.reqId = 5;
                                break;
                            case 3:
                                go.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                                Yrt.reqId = 6;
                                break;
                            case 4:
                                    go.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                                    Yrt.reqId = 7; 
                                break;
                            case 5:
                                int q = UnityEngine.Random.Range(0, 4);
                                switch (q)
                                {
                                    case 0:
                                        go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                                        Yrt.reqId = 1;
                                        break;
                                    case 1:
                                        go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                                        Yrt.reqId = 2;
                                        break;
                                    case 2:
                                        go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                                        Yrt.reqId = 3;
                                        break;
                                    case 3:
                                        go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                                        Yrt.reqId = 4;
                                        break;
                                }
                                break;
                            case 6:
                                go.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                                Yrt.reqId = 9;
                                break;
                            case 7:
                                go.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                                Yrt.reqId = 10;
                                break;
                            case 8:
                                go.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                                Yrt.reqId = 11;
                                break;
                            case 9:
                                go.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                                Yrt.reqId = 12;
                                break;
                            case 11:
                                    go.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                                    Yrt.reqId = 8;
                                break;
                        }
                        break;
                    default:
                        Yrt.req.text = modExcel.myModules.modules[j].requirement;
                        Yrt.reqType = 2;
                        go.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                        break;
                }
            }
            /*int m = System.Random.Range(0, 100);
            if (m >= 0 && m < 75)
            {
                float l = System.Random.Range(0f, 100f);
                if (l <= 3.25f)
                    go.transform.GetChild(12).GetChild(0).gameObject.SetActive(true);
                if (l <= 6.5f && l > 3.25f)
                    go.transform.GetChild(12).GetChild(1).gameObject.SetActive(true);
                if (l <= 9.75f && l > 6.5f)
                    go.transform.GetChild(12).GetChild(2).gameObject.SetActive(true);
                if (l <= 13f && l > 9.75f)
                    go.transform.GetChild(12).GetChild(3).gameObject.SetActive(true);
                if (l <= 16.25f && l > 13f)
                    go.transform.GetChild(12).GetChild(4).gameObject.SetActive(true);
                if (l <= 19.5f && l > 16.25f)
                    go.transform.GetChild(12).GetChild(5).gameObject.SetActive(true);
                if (l <= 22.75f && l > 19.5f)
                    go.transform.GetChild(12).GetChild(6).gameObject.SetActive(true);
                if (l <= 26f && l > 22.75f)
                    go.transform.GetChild(12).GetChild(7).gameObject.SetActive(true);
                if (l <= 29.25f && l > 26f)
                    go.transform.GetChild(12).GetChild(8).gameObject.SetActive(true);
                if (l <= 32.5f && l > 29.25f)
                    go.transform.GetChild(12).GetChild(9).gameObject.SetActive(true);
                if (l <= 35.75f && l > 32.5f)
                    go.transform.GetChild(12).GetChild(10).gameObject.SetActive(true);
                if (l <= 39 && l > 35.75f)
                    go.transform.GetChild(12).GetChild(11).gameObject.SetActive(true);
                if (l <= 42 && l > 39f)
                    go.transform.GetChild(12).GetChild(12).gameObject.SetActive(true);
                if (l <= 45 && l > 42f)
                    go.transform.GetChild(12).GetChild(13).gameObject.SetActive(true);
                if (l <= 48 && l > 45f)
                    go.transform.GetChild(12).GetChild(14).gameObject.SetActive(true);
                if (l <= 51 && l > 48f)
                    go.transform.GetChild(12).GetChild(15).gameObject.SetActive(true);
                if (l <= 54 && l > 51f)
                    go.transform.GetChild(12).GetChild(16).gameObject.SetActive(true);
                if (l <= 57 && l > 54f)
                    go.transform.GetChild(12).GetChild(17).gameObject.SetActive(true);
                if (l <= 60.25f && l > 57f)
                    go.transform.GetChild(12).GetChild(18).gameObject.SetActive(true);
                if (l <= 63.5f && l > 60.25f)
                    go.transform.GetChild(12).GetChild(19).gameObject.SetActive(true);
                if (l <= 66.5 && l > 63.5f)
                    go.transform.GetChild(12).GetChild(20).gameObject.SetActive(true);
                if (l <= 69.5f && l > 66.5f)
                    go.transform.GetChild(12).GetChild(21).gameObject.SetActive(true);
                if (l <= 75.5 && l > 69.5f)
                    go.transform.GetChild(12).GetChild(22).gameObject.SetActive(true);
                if (l <= 81.5f && l > 75.5f)
                    go.transform.GetChild(12).GetChild(23).gameObject.SetActive(true);
                if (l <= 84.5 && l > 81.5f)
                    go.transform.GetChild(12).GetChild(24).gameObject.SetActive(true);
                if (l <= 87.5f && l > 84.5f)
                    go.transform.GetChild(12).GetChild(25).gameObject.SetActive(true);
                if (l <= 90.5 && l > 87.5)
                    go.transform.GetChild(12).GetChild(26).gameObject.SetActive(true);
                if (l <= 93.5 && l > 90.5f)
                    go.transform.GetChild(12).GetChild(27).gameObject.SetActive(true);
                if (l <= 96.75 && l > 93.5f)
                    go.transform.GetChild(12).GetChild(28).gameObject.SetActive(true);
                if (l > 96.75f)
                    go.transform.GetChild(12).GetChild(29).gameObject.SetActive(true);
            }*/


            Destroy(go.transform.GetChild(8).gameObject);
            Image imagen = go.transform.GetComponent<Image>();
            if (Yrt.type == (ModuleType)0)
            {
                imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
                /*stackeos[0]++;
                canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
                if (stackeos[0] < 4)
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                else
                    stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];*/
            }
            if (Yrt.type == (ModuleType)1)
            {
                imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
                /*stackeos[1]++;
                canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = stackeos[1].ToString();
                if (stackeos[1] == 1)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                if (stackeos[1] == 2 || stackeos[1] == 3)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                if (stackeos[1] == 4 || stackeos[1] == 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
                if (stackeos[1] > 5)
                    stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];*/
            }
            if (Yrt.type == (ModuleType)2)
            {
                imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);
                /*stackeos[2]++;
                canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = stackeos[2].ToString();
                if (stackeos[2] == 1)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                if (stackeos[2] == 2 || stackeos[1] == 3)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                if (stackeos[2] == 4 || stackeos[1] == 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
                if (stackeos[2] > 5)
                    stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];*/
            }
            if (Yrt.type == (ModuleType)3)
            {
                imagen.color = new Color(0.7f, 0.7f, 0.7f, 1);
                /*stackeos[3]++;
                canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = stackeos[3].ToString();
                if (stackeos[3] < 4)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
                if (stackeos[3] > 3 && stackeos[3] < 8)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
                if (stackeos[3] > 7)
                    stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];*/

            }
            if (Yrt.type == (ModuleType)4)
            {
                imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);
                /*stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
                if (stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (stackeos[4] > 5 && stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                if (stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
            }
            if (Yrt.type == (ModuleType)5)
            {
                imagen.color = new Color(0, 1, 1, 1);
                /*stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
                if (stackeos[4] < 6)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                if (stackeos[4] > 5 && stackeos[4] < 10)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                if (stackeos[4] > 9)
                    stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];*/
            }
            int n = UnityEngine.Random.Range(0, 100);
            Yrt.sEffectorDefect = 0;
            if (n < 60)
            {
                Sprite[] all = Resources.LoadAll<Sprite>("Effects/SideEffects");
                int l = UnityEngine.Random.Range(0, all.Length);
                Yrt.sideEffectId = l;
                Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
                int p = UnityEngine.Random.Range(0, 4);
                switch (p)
                {
                    case 0:
                        Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                        Yrt.sEffectorDefect = 1;
                        Yrt.sEffectSide = 0;
                        break;
                    case 1:
                        Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                        Yrt.sEffectorDefect = 1;
                        Yrt.sEffectSide = 1;
                        break;
                    case 2:
                        Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                        Yrt.sEffectorDefect = 1;
                        Yrt.sEffectSide = 2;
                        break;
                    case 3:
                        Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                        Yrt.sEffectorDefect = 1;
                        Yrt.sEffectSide = 3;
                        break;
                }
            }
            if (n >= 90)
            {
                Sprite[] all = Resources.LoadAll<Sprite>("Effects/Defects");
                int l = UnityEngine.Random.Range(0, all.Length);
                Yrt.sideEffectId = l;
                Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[l];
                int p = UnityEngine.Random.Range(0, 4);
                switch (p)
                {
                    case 0:
                        Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                        Yrt.sEffectorDefect = 2;
                        Yrt.sEffectSide = 0;
                        break;
                    case 1:
                        Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                        Yrt.sEffectorDefect = 2;
                        Yrt.sEffectSide = 1;
                        break;
                    case 2:
                        Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                        Yrt.sEffectorDefect = 2;
                        Yrt.sEffectSide = 2;
                        break;
                    case 3:
                        Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                        Yrt.sEffectorDefect = 2;
                        Yrt.sEffectSide = 3;
                        break;
                }
            }
        }

        for (int i = 0; i < cyclelength; i++)
        {
            int j = randomTraits.Next(0, 216);
            int l = UnityEngine.Random.Range(0, membersInfo.names.Length);
            int k = 0;
            float random = (float)randomProfessions.NextDouble()*1000;
            if (random < 90f)
                k = 0;
            if (random >= 90f && random < 180f)
                k = 1;
            if (random >= 180f && random < 270f)
                k = 2;
            if (random >= 270f && random < 360f)
                k = 3;
            if (random >= 360f && random < 450f)
                k = 4;
            if (random >= 450f && random < 540f)
                k = 5;
            if (random >= 540f && random < 630f)
                k = 6;
            if (random >= 630f && random < 635f)
                k = 7;
            if (random >= 635f && random < 720f)
                k = 8;
            if (random >= 720f && random < 810f)
                k = 9;
            if (random >= 810f && random < 815f)
                k = 10;
            if (random >= 815f && random < 820f)
                k = 11;
            if (random >= 820f && random < 910f)
                k = 12;
            if (random >= 910f && random < 1000f)
                k = 13;

            GameObject go = Instantiate(memberGenPrefab, new Vector3(272 + i * 163, 934, 0), Quaternion.identity) as GameObject;
            go.transform.parent = membersFolder.transform;
            members.Add(go);
            MemberHUD Yrt = go.GetComponent<MemberHUD>();
            Yrt.nameText.text = membersInfo.names[l];
            Yrt.profDetailsText.text = (ProfessionType)k + " = " + membersInfo.profDescription[k];
            Yrt.traitDetailsText.text = memExcel.myMembers.members[j].trait + " = " + memExcel.myMembers.members[j].tEffect;
            Yrt.traitDetailsText.text = Yrt.traitDetailsText.text.Replace("*", ",");
            Yrt.trait.text = memExcel.myMembers.members[j].trait;
            Yrt.profession = (ProfessionType)k;
            Yrt.profPrice.text = membersInfo.profPrice[k].ToString();
            Yrt.traitPrice.text = Yrt.trait.text + "(" + memExcel.myMembers.members[j].price.ToString() + ") + " + Yrt.profession + "(" + Yrt.profPrice.text + ") = " + (membersInfo.profPrice[k] + memExcel.myMembers.members[j].price).ToString();
            Yrt.totalPrice.text = (membersInfo.profPrice[k] + memExcel.myMembers.members[j].price).ToString();
            Yrt.id = j;
            Yrt.professionId = k;
            float m = UnityEngine.Random.Range(0f, 100f);
            if (m < 70f)
                Yrt.performance = 40;
            if (m >= 70f && m < 93f)
                Yrt.performance = 45;
            if (m >= 93f)
                Yrt.performance = 50;
            SpriteRenderer imagen = go.GetComponent<SpriteRenderer>();
            /*mStackeos[k]++;
            canvas.transform.GetChild(30).GetChild(k + 5).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[k].ToString();*/
            /*switch (k)
            {
                case 0:
                    if (mStackeos[0] > 0 && mStackeos[0] < 3)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                    if (mStackeos[0] > 2 && mStackeos[0] < 6)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                    if (mStackeos[0] > 5)
                        stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                    break;
                case 1:
                    if (mStackeos[1] > 0 && mStackeos[1] < 3)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                    if (mStackeos[1] > 2 && mStackeos[1] < 6)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                    if (mStackeos[1] > 5)
                        stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                    break;
                case 2:
                    if (mStackeos[2] > 0 && mStackeos[2] < 4)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                    if (mStackeos[2] > 3 && mStackeos[2] < 8)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                    if (mStackeos[2] > 7)
                        stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                    break;
                case 3:
                    if (mStackeos[3] > 0 && mStackeos[3] < 3)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                    if (mStackeos[3] > 2 && mStackeos[3] < 6)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                    if (mStackeos[3] > 5)
                        stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                    break;
                case 4:
                    if (mStackeos[4] > 0 && mStackeos[4] < 3)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                    if (mStackeos[4] > 2 && mStackeos[4] < 6)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                    if (mStackeos[4] > 5)
                        stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                    break;
                case 5:
                    if (mStackeos[5] > 0 && mStackeos[5] < 4)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                    if (mStackeos[5] > 3 && mStackeos[5] < 6)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[22];
                    if (mStackeos[5] > 5)
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[23];
                    break;
                case 6:
                    if (mStackeos[6] > 0 && mStackeos[6] < 3)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                    if (mStackeos[6] > 2 && mStackeos[6] < 6)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                    if (mStackeos[6] > 5)
                        stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                    break;
                case 7:
                    if (mStackeos[7] > 0 && mStackeos[7] < 2)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[29];
                    if (mStackeos[7] > 1 && mStackeos[7] < 4)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[30];
                    if (mStackeos[7] > 3)
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[31];
                    break;
                case 8:
                    if (mStackeos[8] > 0 && mStackeos[8] < 3)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                    if (mStackeos[8] > 2 && mStackeos[8] < 6)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                    if (mStackeos[8] > 5)
                        stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                    break;
                case 9:
                    if (mStackeos[9] > 0 && mStackeos[9] < 3)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                    if (mStackeos[9] > 2 && mStackeos[9] < 6)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                    if (mStackeos[9] > 5)
                        stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                    break;
                case 10:
                    if (mStackeos[10] > 0 && mStackeos[10] < 4)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[41];
                    if (mStackeos[10] > 3)
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[43];
                    break;
                case 11:
                        stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[47];
                    break;
            }*/

        }
    }

    public void GenerateMegas(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        if (!int.TryParse(s, out int index))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }
        if (index > 14)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = new GameObject();
        if (index <= 5)
            go = Instantiate(megaHorPrefab, new Vector3(730, 992, 0), Quaternion.identity) as GameObject;
        else
            go = Instantiate(megaVerPrefab, new Vector3(920, 1016, 0), Quaternion.identity) as GameObject;
        go.transform.parent = modulesFolder.transform;
        if (index <= 5)
        {
            MegaHUD ob = go.GetComponent<MegaHUD>();
            ob.detailsText.text = megaInfo.moduleDetails[index];
            ob.type = megaInfo.moduleType[index];
            ob.nameText.text = megaInfo.names[index];
            switch (ob.type)
            {
                case (ModuleType)0:
                    ob.typeDetails.text = modInfo.typeStacking[0];
                    break;
                case (ModuleType)1:
                    ob.typeDetails.text = modInfo.typeStacking[1];
                    break;
                case (ModuleType)2:
                    ob.typeDetails.text = modInfo.typeStacking[2];
                    break;
                case (ModuleType)3:
                    ob.typeDetails.text = modInfo.typeStacking[3];
                    break;
                case (ModuleType)4:
                    ob.typeDetails.text = modInfo.typeStacking[4];
                    break;
                case (ModuleType)5:
                    ob.typeDetails.text = modInfo.typeStacking[5];
                    break;
            }
            switch (megaInfo.req[index])
            {
                case "0":
                    ob.req.text = "No Requirement";
                    break;
                default:
                    ob.req.text = megaInfo.req[index];
                    break;
            }
            ob.sliderLength = megaInfo.cooldown[index];
            SpriteRenderer imagen;
            if (ob.sliderLength == 0)
            {
                imagen = go.transform.GetChild(13).GetComponent<SpriteRenderer>();
                Destroy(go.transform.GetChild(12).gameObject);

            }
            else
            {
                go.transform.GetChild(12).GetComponent<Slider>().maxValue = ob.sliderLength;
                go.transform.GetChild(12).GetComponent<Slider>().value = ob.sliderLength;
                imagen = go.transform.GetChild(13).GetComponent<SpriteRenderer>();
            }
            imagen.sprite = megaInfo.sprites[index];
        }
        else
        {
            MegaVerHUD ob = go.GetComponent<MegaVerHUD>();
            ob.detailsText.text = megaInfo.moduleDetails[index];
            ob.type = megaInfo.moduleType[index];
            ob.nameText.text = megaInfo.names[index];
            switch (ob.type)
            {
                case (ModuleType)0:
                    ob.typeDetails.text = modInfo.typeStacking[0];
                    break;
                case (ModuleType)1:
                    ob.typeDetails.text = modInfo.typeStacking[1];
                    break;
                case (ModuleType)2:
                    ob.typeDetails.text = modInfo.typeStacking[2];
                    break;
                case (ModuleType)3:
                    ob.typeDetails.text = modInfo.typeStacking[3];
                    break;
                case (ModuleType)4:
                    ob.typeDetails.text = modInfo.typeStacking[4];
                    break;
                case (ModuleType)5:
                    ob.typeDetails.text = modInfo.typeStacking[5];
                    break;
            }
            switch (megaInfo.req[index])
            {
                case "0":
                    ob.req.text = "No Requirement";
                    break;
                default:
                    ob.req.text = megaInfo.req[index];
                    break;
            }
            ob.sliderLength = megaInfo.cooldown[index];
            SpriteRenderer imagen;
            if (ob.sliderLength == 0)
            {
                imagen = go.transform.GetChild(11).GetComponent<SpriteRenderer>();
                Destroy(go.transform.GetChild(10).gameObject);
            }
            else
            {
                go.transform.GetChild(10).GetComponent<Slider>().maxValue = ob.sliderLength;
                go.transform.GetChild(10).GetComponent<Slider>().value = ob.sliderLength;
                imagen = go.transform.GetChild(11).GetComponent<SpriteRenderer>();
            }
            imagen.sprite = megaInfo.sprites[index];
        }
        megas.Add(go);
        //ob.nameText.text = megaInfo.names[index];
    }

    public void GenerateBiologicModules(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        if (!int.TryParse(s, out int index))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (index > 34)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = Instantiate(moduleGenPrefab, new Vector3(908, 960, -1), Quaternion.identity) as GameObject;
        go.transform.parent = modulesFolder.transform;
        ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
        modules.Add(go);
        Yrt.nameText.text = bioInfo.names[index];
        Yrt.detailsText.text = bioInfo.moduleDetails[index];
        Yrt.type = (ModuleType)0;
        Yrt.req.text = "No Requirement";
        Yrt.sliderLength = bioInfo.cooldown[index];
        if (Yrt.sliderLength == 0)
        {
            Destroy(go.transform.GetChild(8).gameObject);
        }
        else
        {
            go.transform.GetChild(8).GetComponent<Slider>().maxValue = Yrt.sliderLength;
            go.transform.GetChild(8).GetComponent<Slider>().value = Yrt.sliderLength;
        }
        Yrt.typeDetails.text = modInfo.typeStacking[0];
        stackeos[0]++;
        canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
        Image imagen = go.transform.GetComponent<Image>();
        imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
        if (stackeos[0] < 4)
            stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
        else
            stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];
    }

    public void ResetTurns()
    {

        turn = 0;
        turnCounter.transform.GetComponent<TextMeshProUGUI>().text = turn.ToString();
    }

    IEnumerator AttackModule(GameObject slot)
    {

        yield return new WaitForSeconds(0.23f);

        if (slot.GetComponent<ItemSlot>().member != null)
        {
            if (slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health != 0)
                slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health = slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health - monster.GetComponent<MonsterHUD>().crewDMG;
            switch (slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health)
            {
                case 4:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(0, 241, 81, 255);
                    yield break;
                case 3:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(226, 238, 11, 255);
                    yield break;
                case 2:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(244, 168, 26, 255);
                    yield break;
                case 1:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(254, 69, 7, 255);
                    yield break;
                case 0:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
                    yield break;
                default:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(17, 205, 238, 255);
                    yield break;
            }
        }
    }

    private void Update()
    {
        foreach (GameObject module in modules)
        {
            if (module.transform.position.x > 661.5f && module.transform.position.x < 1682.8f && module.transform.position.y > 267.1f && module.transform.position.y < 864.2 && module.GetComponent<ModuleHUD>().insideField == false)
            {
                GameObject canvas = GameObject.Find("/Malla");
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)0)
                {
                    stackeos[0]++;
                    canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
                    if (stackeos[0] < 6)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                    else
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[93];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)1)
                {
                    stackeos[1]++;
                    canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = stackeos[1].ToString();
                    if (stackeos[1] <= 3)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[53];
                    if (stackeos[1] >= 4 && stackeos[1] <= 7)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                    if (stackeos[1] >= 8 && stackeos[1] <= 11)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                    if (stackeos[1] >= 12)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)2)
                {
                    stackeos[2]++;
                    canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = stackeos[2].ToString();
                    if (stackeos[2] <= 3)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[58];
                    if (stackeos[2] >= 4 && stackeos[2] <= 7)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                    if (stackeos[2] >= 8 && stackeos[2] <= 11)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                    if (stackeos[2] >= 12)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)3)
                {
                    stackeos[3]++;
                    canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = stackeos[3].ToString();
                    if (stackeos[3] <= 3)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
                    if (stackeos[3] >= 4 && stackeos[3] <= 7)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[68];
                    if (stackeos[3] >= 8 && stackeos[3] <= 11)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
                    if (stackeos[3] >= 12)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[95];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)4)
                {
                    stackeos[4]++;
                    canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
                    if (stackeos[4] <= 3)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                    if (stackeos[4] >= 4 && stackeos[4] <= 7)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                    if (stackeos[4] >= 8 && stackeos[4] <= 11)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
                    if (stackeos[4] >= 12)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[94];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)5)
                {
                    stackeos[4]++;
                    canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
                    if (stackeos[4] <= 3)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                    if (stackeos[4] >= 4 && stackeos[4] <= 7)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                    if (stackeos[4] >= 8 && stackeos[4] <= 11)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
                    if (stackeos[4] >= 12)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[94];
                }
                module.GetComponent<ModuleHUD>().insideField = true;
            }
            if (!(module.transform.position.x > 661.5f && module.transform.position.x < 1682.8f && module.transform.position.y > 267.1f && module.transform.position.y < 864.2) && module.GetComponent<ModuleHUD>().insideField)
            {
                GameObject canvas = GameObject.Find("/Malla");
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)0)
                {
                    stackeos[0]--;
                    canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = stackeos[0].ToString();
                    if (stackeos[0] == 0)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[48];
                    if (stackeos[0] > 0 && stackeos[0] < 6)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[49];
                    if (stackeos[0] >= 6)
                        stackingFolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[93];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)1)
                {
                    stackeos[1]--;
                    canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = stackeos[1].ToString();
                    if (stackeos[1] == 0)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[52];
                    if (stackeos[1] <= 3 && stackeos[1] > 0)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[53];
                    if (stackeos[1] >= 4 && stackeos[1] <= 7)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[54];
                    if (stackeos[1] >= 8 && stackeos[1] <= 11)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[55];
                    if (stackeos[1] >= 12)
                        stackingFolder.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[56];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)2)
                {
                    stackeos[2]--;
                    canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = stackeos[2].ToString();
                    if (stackeos[2] == 0)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[57];
                    if (stackeos[2] <= 3 && stackeos[2] > 0)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[58];
                    if (stackeos[2] >= 4 && stackeos[2] <= 7)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[59];
                    if (stackeos[2] >= 8 && stackeos[2] <= 11)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[60];
                    if (stackeos[2] >= 12)
                        stackingFolder.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[61];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)3)
                {
                    stackeos[3]--;
                    canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = stackeos[3].ToString();
                    if (stackeos[3] == 0)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[66];
                    if (stackeos[3] <= 3 && stackeos[3] > 0)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[67];
                    if (stackeos[3] >= 4 && stackeos[3] <= 7)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[68];
                    if (stackeos[3] >= 8 && stackeos[3] <= 11)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[69];
                    if (stackeos[3] >= 12)
                        stackingFolder.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[95];
                }
                if (module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)4 || module.gameObject.GetComponent<ModuleHUD>().type == (ModuleType)5)
                {
                    stackeos[4]--;
                    canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = stackeos[4].ToString();
                    if (stackeos[4] == 0)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[62];
                    if (stackeos[4] <= 3 && stackeos[4] > 0)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[63];
                    if (stackeos[4] >= 4 && stackeos[4] <= 7)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[64];
                    if (stackeos[4] >= 8 && stackeos[4] <= 11)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[65];
                    if (stackeos[4] >= 12)
                        stackingFolder.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[94];
                }
                module.GetComponent<ModuleHUD>().insideField = false;
            }
        }
        foreach (GameObject member in members)
        {
            if (member.transform.position.x > 661.5f && member.transform.position.x < 1682.8f && member.transform.position.y > 267.1f && member.transform.position.y < 864.2 && member.GetComponent<MemberHUD>().insideField == false)
            {
                GameObject canvas = GameObject.Find("/Malla");
                switch (member.gameObject.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        mStackeos[0]++;
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[0].ToString();
                        if (mStackeos[0] > 0 && mStackeos[0] < 4)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                        if (mStackeos[0] >= 4 && mStackeos[0] <= 7)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                        if (mStackeos[0] >= 8 && mStackeos[0] <= 11)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                        if (mStackeos[0] >= 12)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[70];
                        break;
                    case (ProfessionType)1:
                        mStackeos[1]++;
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[1].ToString();
                        if (mStackeos[1] > 0 && mStackeos[1] < 4)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                        if (mStackeos[1] >= 4 && mStackeos[1] <= 7)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                        if (mStackeos[1] >= 8 && mStackeos[1] <= 11)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                        if (mStackeos[1] >= 12)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[74];
                        break;
                    case (ProfessionType)2:
                        mStackeos[2]++;
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[2].ToString();
                        if (mStackeos[2] > 0 && mStackeos[2] < 4)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                        if (mStackeos[2] >= 4 && mStackeos[2] <= 7)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                        if (mStackeos[2] >= 8 && mStackeos[2] <= 11)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                        if (mStackeos[2] >= 12)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[73];
                        break;
                    case (ProfessionType)3:
                        mStackeos[3]++;
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[3].ToString();
                        if (mStackeos[3] > 0 && mStackeos[3] < 4)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                        if (mStackeos[3] >= 4 && mStackeos[3] <= 7)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                        if (mStackeos[3] >= 8 && mStackeos[3] <= 11)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                        if (mStackeos[3] >= 12)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[77];
                        break;
                    case (ProfessionType)4:
                        mStackeos[4]++;
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[4].ToString();
                        if (mStackeos[4] > 0 && mStackeos[4] < 4)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                        if (mStackeos[4] >= 4 && mStackeos[4] <= 7)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                        if (mStackeos[4] >= 8 && mStackeos[4] <= 11)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                        if (mStackeos[4] >= 12)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[76];
                        break;
                    case (ProfessionType)5:
                        mStackeos[5]++;
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[5].ToString();
                        stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                        break;
                    case (ProfessionType)6:
                        mStackeos[6]++;
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[6].ToString();
                        if (mStackeos[6] > 0 && mStackeos[6] < 4)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                        if (mStackeos[6] >= 4 && mStackeos[6] <= 7)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                        if (mStackeos[6] >= 8 && mStackeos[6] <= 11)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                        if (mStackeos[6] >= 12)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[78];
                        break;
                    case (ProfessionType)7:
                        mStackeos[7]++;
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[7].ToString();
                        stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[75];
                        break;
                    case (ProfessionType)8:
                        mStackeos[8]++;
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[8].ToString();
                        if (mStackeos[8] > 0 && mStackeos[8] < 4)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                        if (mStackeos[8] >= 4 && mStackeos[8] <= 7)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                        if (mStackeos[8] >= 8 && mStackeos[8] <= 11)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                        if (mStackeos[8] >= 12)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[80];
                        break;
                    case (ProfessionType)9:
                        mStackeos[9]++;
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[9].ToString();
                        if (mStackeos[9] > 0 && mStackeos[9] < 4)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                        if (mStackeos[9] >= 4 && mStackeos[9] <= 7)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                        if (mStackeos[9] >= 8 && mStackeos[9] <= 11)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                        if (mStackeos[9] >= 12)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[81];
                        break;
                    case (ProfessionType)10:
                        mStackeos[10]++;
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[10].ToString();
                        stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
                        break;
                    case (ProfessionType)11:
                        mStackeos[11]++;
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[11].ToString();
                        stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];
                        break;
                    case (ProfessionType)12:
                        mStackeos[12]++;
                        canvas.transform.GetChild(30).GetChild(17).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[12].ToString();
                        if (mStackeos[12] > 0 && mStackeos[12] < 4)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[84];
                        if (mStackeos[12] >= 4 && mStackeos[12] <= 7)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[86];
                        if (mStackeos[12] >= 8 && mStackeos[12] <= 11)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[88];
                        if (mStackeos[12] >= 12)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[90];
                        break;
                    case (ProfessionType)13:
                        mStackeos[13]++;
                        canvas.transform.GetChild(30).GetChild(18).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[13].ToString();
                        if (mStackeos[13] > 0 && mStackeos[13] < 4)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[85];
                        if (mStackeos[13] >= 4 && mStackeos[13] <= 7)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[87];
                        if (mStackeos[13] >= 8 && mStackeos[13] <= 11)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[89];
                        if (mStackeos[13] >= 12)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[91];
                        break;

                }
                member.GetComponent<MemberHUD>().insideField = true;
            }
            if (!(member.transform.position.x > 661.5f && member.transform.position.x < 1682.8f && member.transform.position.y > 267.1f && member.transform.position.y < 864.2) && member.GetComponent<MemberHUD>().insideField)
            {
                GameObject canvas = GameObject.Find("/Malla");
                switch (member.gameObject.GetComponent<MemberHUD>().profession)
                {
                    case (ProfessionType)0:
                        mStackeos[0]--;
                        canvas.transform.GetChild(30).GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[0].ToString();
                        if (mStackeos[0] == 0)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[0];
                        if (mStackeos[0] > 0 && mStackeos[0] < 4)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[1];
                        if (mStackeos[0] >= 4 && mStackeos[0] <= 7)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[2];
                        if (mStackeos[0] >= 8 && mStackeos[0] <= 11)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[3];
                        if (mStackeos[0] >= 12)
                            stackingFolder.transform.GetChild(5).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[70];
                        break;
                    case (ProfessionType)1:
                        mStackeos[1]--;
                        canvas.transform.GetChild(30).GetChild(6).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[1].ToString();
                        if (mStackeos[1] == 0)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[4];
                        if (mStackeos[1] > 0 && mStackeos[1] < 4)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[5];
                        if (mStackeos[1] >= 4 && mStackeos[1] <= 7)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[6];
                        if (mStackeos[1] >= 8 && mStackeos[1] <= 11)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[7];
                        if (mStackeos[1] >= 12)
                            stackingFolder.transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[74];
                        break;
                    case (ProfessionType)2:
                        mStackeos[2]--;
                        canvas.transform.GetChild(30).GetChild(7).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[2].ToString();
                        if (mStackeos[2] == 0)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[8];
                        if (mStackeos[2] > 0 && mStackeos[2] < 4)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[9];
                        if (mStackeos[2] >= 4 && mStackeos[2] <= 7)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[10];
                        if (mStackeos[2] >= 8 && mStackeos[2] <= 11)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[11];
                        if (mStackeos[2] >= 12)
                            stackingFolder.transform.GetChild(7).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[73];
                        break;
                    case (ProfessionType)3:
                        mStackeos[3]--;
                        canvas.transform.GetChild(30).GetChild(8).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[3].ToString();
                        if (mStackeos[3] == 0)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[12];
                        if (mStackeos[3] > 0 && mStackeos[3] < 4)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[13];
                        if (mStackeos[3] >= 4 && mStackeos[3] <= 7)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[14];
                        if (mStackeos[3] >= 8 && mStackeos[3] <= 11)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[15];
                        if (mStackeos[3] >= 12)
                            stackingFolder.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[77];
                        break;
                    case (ProfessionType)4:
                        mStackeos[4]--;
                        canvas.transform.GetChild(30).GetChild(9).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[4].ToString();
                        if (mStackeos[4] == 0)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[16];
                        if (mStackeos[4] > 0 && mStackeos[4] < 4)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[17];
                        if (mStackeos[4] >= 4 && mStackeos[4] <= 7)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[18];
                        if (mStackeos[4] >= 8 && mStackeos[4] <= 11)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[19];
                        if (mStackeos[4] >= 12)
                            stackingFolder.transform.GetChild(9).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[76];
                        break;
                    case (ProfessionType)5:
                        mStackeos[5]--;
                        canvas.transform.GetChild(30).GetChild(10).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[5].ToString();
                        if (mStackeos[5] == 0)
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[20];
                        else
                            stackingFolder.transform.GetChild(10).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[21];
                        break;
                    case (ProfessionType)6:
                        mStackeos[6]--;
                        canvas.transform.GetChild(30).GetChild(11).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[6].ToString();
                        if (mStackeos[6] == 0)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[24];
                        if (mStackeos[6] > 0 && mStackeos[6] < 4)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[25];
                        if (mStackeos[6] >= 4 && mStackeos[6] <= 7)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[26];
                        if (mStackeos[6] >= 8 && mStackeos[6] <= 11)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[27];
                        if (mStackeos[6] >= 12)
                            stackingFolder.transform.GetChild(11).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[78];
                        break;
                    case (ProfessionType)7:
                        mStackeos[7]--;
                        canvas.transform.GetChild(30).GetChild(12).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[7].ToString();
                        if (mStackeos[7] == 0)
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[28];
                        else
                            stackingFolder.transform.GetChild(12).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[75];
                        break;
                    case (ProfessionType)8:
                        mStackeos[8]--;
                        canvas.transform.GetChild(30).GetChild(13).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[8].ToString();
                        if (mStackeos[8] == 0)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[32];
                        if (mStackeos[8] > 0 && mStackeos[8] < 4)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[33];
                        if (mStackeos[8] >= 4 && mStackeos[8] <= 7)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[34];
                        if (mStackeos[8] >= 8 && mStackeos[8] <= 11)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[35];
                        if (mStackeos[8] >= 12)
                            stackingFolder.transform.GetChild(13).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[80];
                        break;
                    case (ProfessionType)9:
                        mStackeos[9]--;
                        canvas.transform.GetChild(30).GetChild(14).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[9].ToString();
                        if (mStackeos[9] == 0)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[36];
                        if (mStackeos[9] > 0 && mStackeos[9] < 4)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[37];
                        if (mStackeos[9] >= 4 && mStackeos[9] <= 7)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[38];
                        if (mStackeos[9] >= 8 && mStackeos[9] <= 11)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[39];
                        if (mStackeos[9] >= 12)
                            stackingFolder.transform.GetChild(14).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[81];
                        break;
                    case (ProfessionType)10:
                        mStackeos[10]--;
                        canvas.transform.GetChild(30).GetChild(15).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[10].ToString();
                        if (mStackeos[10] == 0)
                            stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[40];
                        else
                            stackingFolder.transform.GetChild(15).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[71];
                        break;
                    case (ProfessionType)11:
                        mStackeos[11]--;
                        canvas.transform.GetChild(30).GetChild(16).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[11].ToString();
                        if (mStackeos[11] == 0)
                            stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[44];
                        else
                            stackingFolder.transform.GetChild(16).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[72];
                        break;
                    case (ProfessionType)12:
                        mStackeos[12]--;
                        canvas.transform.GetChild(30).GetChild(17).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[12].ToString();
                        if (mStackeos[12] == 0)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[82];
                        if (mStackeos[12] > 0 && mStackeos[12] < 4)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[84];
                        if (mStackeos[12] >= 4 && mStackeos[12] <= 7)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[86];
                        if (mStackeos[12] >= 8 && mStackeos[12] <= 11)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[88];
                        if (mStackeos[12] >= 12)
                            stackingFolder.transform.GetChild(17).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[90];
                        break;
                    case (ProfessionType)13:
                        mStackeos[13]--;
                        canvas.transform.GetChild(30).GetChild(18).GetChild(0).GetComponent<TMP_Text>().text = mStackeos[13].ToString();
                        if (mStackeos[13] == 0)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[83];
                        if (mStackeos[13] > 0 && mStackeos[13] < 4)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[85];
                        if (mStackeos[13] >= 4 && mStackeos[13] <= 7)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[87];
                        if (mStackeos[13] >= 8 && mStackeos[13] <= 11)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[89];
                        if (mStackeos[13] >= 12)
                            stackingFolder.transform.GetChild(18).GetComponent<SpriteRenderer>().sprite = stackingIcons.sprites[91];
                        break;

                }
                member.GetComponent<MemberHUD>().insideField = false;
            }
        }
    }

    /*public void OnSave()
    {
        foreach (GameObject module in modules)
        {
            SaveData.current.modules.Add(module);
        }
        SerializationManager.Save("modules", SaveData.current);
    }

    public void OnLoad()
    {
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/modules.save");

        foreach (GameObject module in SaveData.current.modules)
        {
            GameObject obj = Instantiate(moduleGenPrefab, new Vector3(908, 960, 0), Quaternion.identity) as GameObject;
            obj.GetComponent<ModuleHUD>().nameText.text = module.GetComponent<ModuleHUD>().nameText.text;
            obj.GetComponent<ModuleHUD>().detailsText.text = module.GetComponent<ModuleHUD>().detailsText.text;
            modules.Add(obj);
        }
    }*/

    public void OnSave()
    {

        SaveData.current.posX.Clear();
        SaveData.current.posY.Clear();
        SaveData.current.posZ.Clear();
        SaveData.current.id.Clear();
        SaveData.current.req.Clear();
        SaveData.current.sideE.Clear();
        SaveData.current.sEffectorDefect.Clear();
        SaveData.current.sEffectSide.Clear();
        SaveData.current.reqActive.Clear();
        SaveData.current.memName.Clear();
        SaveData.current.memPosX.Clear();
        SaveData.current.memPosY.Clear();
        SaveData.current.memPosZ.Clear();
        SaveData.current.memId.Clear();
        SaveData.current.memId2.Clear();
        SaveData.current.memHealth.Clear();
        SaveData.current.memPerformance.Clear();
        SaveData.current.memProfessionId.Clear();
        SaveData.current.memId2Active.Clear();
        SaveData.current.itemPosX.Clear();
        SaveData.current.itemPosY.Clear();
        SaveData.current.itemPosZ.Clear();
        SaveData.current.objectsId.Clear();
        SaveData.current.coinsLeft = currency.transform.GetComponent<Currency>().money;
        SaveData.current.scrapLeft = currency2.transform.GetComponent<Currency>().money;
        SaveData.current.fuelLeft = fuel.transform.GetComponent<UpdateFuel>().fuel;
        SaveData.current.healthLeft = playerHPBar.transform.GetComponent<Slider>().value;

        foreach (GameObject module in modules)
        {
            SaveData.current.posX.Add(module.transform.position.x);
            SaveData.current.posY.Add(module.transform.position.y);
            SaveData.current.posZ.Add(module.transform.position.z);
            SaveData.current.id.Add(module.transform.GetComponent<ModuleHUD>().id);
            SaveData.current.req.Add(module.transform.GetComponent<ModuleHUD>().reqId);
            SaveData.current.sideE.Add(module.transform.GetComponent<ModuleHUD>().sideEffectId);
            SaveData.current.sEffectorDefect.Add(module.transform.GetComponent<ModuleHUD>().sEffectorDefect);
            SaveData.current.sEffectSide.Add(module.transform.GetComponent<ModuleHUD>().sEffectSide);
            SaveData.current.reqActive.Add(module.transform.GetComponent<ModuleHUD>().reqActive);
        }
        foreach (GameObject member in members)
        {
            SaveData.current.memPosX.Add(member.transform.position.x);
            SaveData.current.memPosY.Add(member.transform.position.y);
            SaveData.current.memPosZ.Add(member.transform.position.z);
            SaveData.current.memId.Add(member.transform.GetComponent<MemberHUD>().id);
            SaveData.current.memId2.Add(member.transform.GetComponent<MemberHUD>().id2);
            SaveData.current.memHealth.Add(member.transform.GetComponent<MemberHUD>().health);
            SaveData.current.memPerformance.Add(member.transform.GetComponent<MemberHUD>().performance);
            SaveData.current.memProfessionId.Add(member.transform.GetComponent<MemberHUD>().professionId);
            SaveData.current.memId2Active.Add(member.transform.GetComponent<MemberHUD>().id2Active);
            SaveData.current.memName.Add(member.transform.GetComponent<MemberHUD>().nameText.text);

        }

        foreach (GameObject objeto in itemSpawner.transform.GetComponent<ItemSpawner>().objectList)
        {
            SaveData.current.objectsId.Add(itemSpawner.transform.GetComponent<ItemSpawner>().objectListId[itemSpawner.transform.GetComponent<ItemSpawner>().objectList.IndexOf(objeto)]);
            SaveData.current.itemPosX.Add(objeto.transform.position.x);
            SaveData.current.itemPosY.Add(objeto.transform.position.y);
            SaveData.current.itemPosZ.Add(objeto.transform.position.z);
        }

        SerializationManager.Save("savedGame", SaveData.current);
    }

    public void OnLoad()
    {
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/savedGame.save");

        currency.transform.GetComponent<Currency>().ChangeCurrency(SaveData.current.coinsLeft.ToString());
        currency2.transform.GetComponent<Currency>().ChangeCurrency(SaveData.current.scrapLeft.ToString());
        fuel.transform.GetComponent<UpdateFuel>().UpdateF((SaveData.current.fuelLeft - 8).ToString());
        playerHPBar.transform.GetComponent<DecreaseHPShip>().ReadStringInput((-(3000 - SaveData.current.healthLeft)).ToString());
        //GameObject obj = Instantiate(moduleGenPrefab, new Vector3(SaveData.current.posX, SaveData.current.posY, SaveData.current.posZ), Quaternion.identity) as GameObject;
        for (int i = 0; i < SaveData.current.posX.Count; i++)
        {
            GameObject obj = Instantiate(moduleGenPrefab, new Vector3(SaveData.current.posX[i], SaveData.current.posY[i], SaveData.current.posZ[i]), Quaternion.identity) as GameObject;
            GameObject canvas = GameObject.Find("/Malla");
            GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
            GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
            obj.transform.parent = modulesFolder.transform;
            ModuleHUD Yrt = obj.GetComponent<ModuleHUD>();
            modules.Add(obj);
            int j = SaveData.current.id[i];
            Yrt.nameText.text = modExcel.myModules.modules[j].name;
            Yrt.detailsText.text = modExcel.myModules.modules[j].effect;
            Yrt.detailsText.text = Yrt.detailsText.text.Replace("*", ",");
            Yrt.detailsText.text = Yrt.detailsText.text.Replace("&quote;", "");
            Yrt.price = modExcel.myModules.modules[j].price;
            Yrt.type = modExcel.myModules.modules[j].type;
            Yrt.id = j;
            Yrt.reqId = SaveData.current.req[i];
            Yrt.reqActive = SaveData.current.reqActive[i];
            switch (Yrt.type)
            {
                case (ModuleType)0:
                    Yrt.typeDetails.text = modInfo.typeStacking[0];
                    break;
                case (ModuleType)1:
                    Yrt.typeDetails.text = modInfo.typeStacking[1];
                    break;
                case (ModuleType)2:
                    Yrt.typeDetails.text = modInfo.typeStacking[2];
                    break;
                case (ModuleType)3:
                    Yrt.typeDetails.text = modInfo.typeStacking[3];
                    break;
                case (ModuleType)4:
                    Yrt.typeDetails.text = modInfo.typeStacking[4];
                    break;
                case (ModuleType)5:
                    Yrt.typeDetails.text = modInfo.typeStacking[5];
                    break;
            }
            if (Yrt.reqActive)
            {
                switch (modExcel.myModules.modules[j].requirement)
                {
                    case "":
                        Yrt.reqType = 1;
                        switch (Yrt.reqId)
                        {
                            case 0:
                                obj.transform.GetChild(11).GetChild(9).gameObject.SetActive(true);
                                break;
                            case 1:
                                obj.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                                break;
                            case 2:
                                obj.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                                break;
                            case 3:
                                obj.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                                break;
                            case 4:
                                obj.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                                break;
                            case 5:
                                obj.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                                break;
                            case 6:
                                obj.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                                break;
                            case 7:
                                obj.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                                break;
                            case 8:
                                obj.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                                break;
                            case 9:
                                obj.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                                break;
                            case 10:
                                obj.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                                break;
                            case 11:
                                obj.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                                break;
                            case 12:
                                obj.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                                break;
                        }
                        break;
                    default:
                        Yrt.req.text = modExcel.myModules.modules[j].requirement;
                        Yrt.reqType = 2;
                        obj.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                        break;
                }
            }
            Destroy(obj.transform.GetChild(8).gameObject);
            Image imagen = obj.transform.GetComponent<Image>();
            if (Yrt.type == (ModuleType)0)
            {
                imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);

            }
            if (Yrt.type == (ModuleType)1)
            {
                imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);

            }
            if (Yrt.type == (ModuleType)2)
            {
                imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);

            }
            if (Yrt.type == (ModuleType)3)
            {
                imagen.color = new Color(0.7f, 0.7f, 0.7f, 1);


            }
            if (Yrt.type == (ModuleType)4)
            {
                imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);

            }
            if (Yrt.type == (ModuleType)5)
            {
                imagen.color = new Color(0, 1, 1, 1);

            }
            Yrt.sEffectorDefect = SaveData.current.sEffectorDefect[i];
            Yrt.sEffectSide = SaveData.current.sEffectSide[i];
            Yrt.sideEffectId = SaveData.current.sideE[i];
            Debug.Log("La info que quieres en Step 1 es " + Yrt.sEffectorDefect + " " + Yrt.sEffectSide + " " + Yrt.sideEffectId);
            if (Yrt.sEffectorDefect == 1)
            {
                Sprite[] all = Resources.LoadAll<Sprite>("Effects/SideEffects");
                Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[Yrt.sideEffectId];
                switch (Yrt.sEffectSide)
                {
                    case 0:
                        Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                        break;
                    case 1:
                        Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                        break;
                    case 2:
                        Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                        break;
                    case 3:
                        Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                        break;
                }
            }
            if (Yrt.sEffectorDefect == 2)
            {
                Sprite[] all = Resources.LoadAll<Sprite>("Effects/Defects");
                Yrt.sideEffect.GetComponent<SpriteRenderer>().sprite = all[Yrt.sideEffectId];
                switch (Yrt.sEffectSide)
                {
                    case 0:
                        Yrt.sideEffect.transform.position += new Vector3(0, 45, 0);
                        break;
                    case 1:
                        Yrt.sideEffect.transform.position += new Vector3(0, -45, 0);
                        break;
                    case 2:
                        Yrt.sideEffect.transform.position += new Vector3(80, 10, 0);
                        break;
                    case 3:
                        Yrt.sideEffect.transform.position += new Vector3(-80, 10, 0);
                        break;
                }
            }
        }
        for (int i = 0; i < SaveData.current.memPosX.Count; i++)
        {
            GameObject obj = Instantiate(memberGenPrefab, new Vector3(SaveData.current.memPosX[i], SaveData.current.memPosY[i], SaveData.current.memPosZ[i]), Quaternion.identity) as GameObject;
            GameObject canvas = GameObject.Find("/Malla");
            GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
            GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
            obj.transform.parent = membersFolder.transform;
            MemberHUD Yrt = obj.GetComponent<MemberHUD>();
            members.Add(obj);
            int k = SaveData.current.memId[i];
            int m = SaveData.current.memProfessionId[i];
            int n = SaveData.current.memId2[i];
            Yrt.nameText.text = SaveData.current.memName[i];
            Yrt.profDetailsText.text = (ProfessionType)m + " = " + membersInfo.profDescription[m];
            Yrt.traitDetailsText.text = memExcel.myMembers.members[k].trait + " = " + memExcel.myMembers.members[k].tEffect;
            Yrt.traitDetailsText.text = Yrt.traitDetailsText.text.Replace("*", ",");
            Yrt.trait.text = memExcel.myMembers.members[k].trait;
            Yrt.profession = (ProfessionType)m;
            Yrt.profPrice.text = membersInfo.profPrice[m].ToString();
            Yrt.traitPrice.text = Yrt.trait.text + "(" + memExcel.myMembers.members[k].price.ToString() + ") + " + Yrt.profession + "(" + Yrt.profPrice.text + ") = " + (membersInfo.profPrice[m] + memExcel.myMembers.members[k].price).ToString();
            Yrt.totalPrice.text = (membersInfo.profPrice[m] + memExcel.myMembers.members[k].price).ToString();
            Yrt.id = k;
            Yrt.id2 = n;
            if (SaveData.current.memId2Active[i])
            {
                Yrt.secTrait.text = memExcel.myMembers.members[n].trait;
                Yrt.secTraitDescription.text = memExcel.myMembers.members[n].trait + " = " + memExcel.myMembers.members[n].tEffect;
                Yrt.secTraitDescription.text = Yrt.secTraitDescription.text.Replace("*", ",");
            }
            Yrt.professionId = m;
            Yrt.performance = SaveData.current.memPerformance[i];
            Yrt.health = SaveData.current.memHealth[i];
        }

        for (int i = 0; i < SaveData.current.objectsId.Count; i++)
        {
            itemSpawner.transform.GetComponent<ItemSpawner>().SpawnObjectWArg2(SaveData.current.objectsId[i].ToString(), SaveData.current.itemPosX[i], SaveData.current.itemPosY[i], SaveData.current.itemPosZ[i]);

        }
    }

}
