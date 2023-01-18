using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using BayatGames.SaveGameFree;
using UnityEngine.Video;

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
    public int[] mStackeos = new int[12];
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

    void  PlayerTurn()
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
                GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(745 + (i * 171), 300 + (102* j), 0), Quaternion.identity) as GameObject;
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
                    goo.GetComponent<Image>().color = new  Color32(60, 200, 64, 255);
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
        turnCounter.transform.GetComponent<TextMeshProUGUI>().text = turn.ToString();
        if ((turn % 2) == 1 && enemyHPBar.GetComponent<Slider>().value != 0)
        {
            playerHPBar.GetComponent<DecreaseHPShip>().ReadStringInput(((monster.GetComponent<MonsterHUD>().dPT) * -1).ToString());
            monster.GetComponent<Animator>().Play("Monster_Attack");
            List<GameObject> activatedModules = new List<GameObject>();
            for (int j = 0; j < 36; j++)
            {
                if (slots[j].GetComponent<ActivateSlot>().activated && slots[j].GetComponent<ItemSlot>().module != null)
                    activatedModules.Add(slots[j]);
            }
            int i = Random.Range(0, activatedModules.Count);
            Vector3 pos = activatedModules[i].transform.position;
            StartCoroutine(PlayExplosion(pos + new Vector3(-25, 0, 0)));
            StartCoroutine(AttackModule(activatedModules[i]));
        }
        if ((turn % 2) == 0)
        {
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
        yield return new WaitForSeconds(0.15f);
        spark.transform.position = pos;
        spark.GetComponent<VideoPlayer>().Play();
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

    public void GenerateModules(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        int k = Random.Range(0, 13);
        if (!int.TryParse(s, out int index))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (index > 164)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = Instantiate(moduleGenPrefab, new Vector3(908, 960, 0), Quaternion.identity) as GameObject;
        go.transform.parent = modulesFolder.transform;
        ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
        modules.Add(go);
        Yrt.nameText.text = modInfo.names[index];
        Yrt.detailsText.text = modInfo.names[index] + " = " + modInfo.moduleDetails[index];
        Yrt.price = modInfo.modulePrice[index];
        Yrt.type = modInfo.moduleType[index];
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
                        break;
                    case 1:
                        go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                        break;
                    case 2:
                        go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                        break;
                    case 3:
                        go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                        break;
                    case 4:
                        go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                        break;
                    case 5:
                        go.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                        break;
                    case 6:
                        go.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                        break;
                    case 7:
                        go.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                        break;
                    case 8:
                        go.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                        break;
                    case 9:
                        go.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                        break;
                    case 10:
                        go.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                        break;
                    case 11:
                        go.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                        break;
                    case 12:
                        go.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                        break;
                }
                break;
            default:
                Yrt.req.text = modInfo.req[index];
                Yrt.reqType = 2;
                go.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                break;
        }
        int m = Random.Range(0, 2);
        if (m == 0)
        {
            float l = Random.Range(0f, 100f);
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
        }

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
    }

    public void GenerateMembers(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        GameObject canvas = GameObject.Find("/Malla");
        GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
        int l = Random.Range(0, membersInfo.names.Length);
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

    public void Generate(string s)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            return;
        if (!int.TryParse(s, out int cyclelength))
        {
            Debug.Log("Try inputting a valid integer");
            return;
        }

        if (cyclelength > 5)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        GameObject membersFolder = canvas.transform.GetChild(28).gameObject;
        for (int i = 0; i < cyclelength; i++)
        {
            int j = Random.Range(0, 165);
            int k = Random.Range(0, 13);
            GameObject go = Instantiate(moduleGenPrefab, new Vector3(272 + i * 163, 1016, 0), Quaternion.identity) as GameObject;
            go.transform.parent = modulesFolder.transform;
            ModuleHUD Yrt = go.GetComponent<ModuleHUD>();
            modules.Add(go);
            Debug.Log(modInfo.names[j]);
            Yrt.nameText.text = modInfo.names[j];
            Yrt.detailsText.text = modInfo.names[j] + " = " + modInfo.moduleDetails[j];
            Yrt.price = modInfo.modulePrice[j];
            Yrt.type = modInfo.moduleType[j];
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
            switch (modInfo.req[j])
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
                            break;
                        case 1:
                            go.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
                            break;
                        case 2:
                            go.transform.GetChild(11).GetChild(4).gameObject.SetActive(true);
                            break;
                        case 3:
                            go.transform.GetChild(11).GetChild(6).gameObject.SetActive(true);
                            break;
                        case 4:
                            go.transform.GetChild(11).GetChild(7).gameObject.SetActive(true);
                            break;
                        case 5:
                            go.transform.GetChild(11).GetChild(8).gameObject.SetActive(true);
                            break;
                        case 6:
                            go.transform.GetChild(11).GetChild(12).gameObject.SetActive(true);
                            break;
                        case 7:
                            go.transform.GetChild(11).GetChild(2).gameObject.SetActive(true);
                            break;
                        case 8:
                            go.transform.GetChild(11).GetChild(3).gameObject.SetActive(true);
                            break;
                        case 9:
                            go.transform.GetChild(11).GetChild(1).gameObject.SetActive(true);
                            break;
                        case 10:
                            go.transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
                            break;
                        case 11:
                            go.transform.GetChild(11).GetChild(10).gameObject.SetActive(true);
                            break;
                        case 12:
                            go.transform.GetChild(11).GetChild(11).gameObject.SetActive(true);
                            break;
                    }
                    break;
                default:
                    Yrt.req.text = modInfo.req[j];
                    Yrt.reqType = 2;
                    go.transform.GetChild(11).GetChild(13).gameObject.SetActive(true);
                    break;
            }
            int m = Random.Range(0, 2);
            if (m == 0)
            {
                float l = Random.Range(0f, 100f);
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
            }

            Yrt.sliderLength = modInfo.cooldown[j];
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
        }

        for (int i = 0; i < cyclelength; i++)
        {
            int j = Random.Range(0, 190);
            int l = Random.Range(0, membersInfo.names.Length);
            int k = 0;
            float random = Random.Range(0f, 100f);
            if (random < 9f)
                k = 0;
            if (random >= 9f && random < 18f)
                k = 1;
            if (random >= 18f && random < 27f)
                k = 2;
            if (random >= 27f && random < 36f)
                k = 3;
            if (random >= 36f && random < 45f)
                k = 4;
            if (random >= 45f && random < 54f)
                k = 5;
            if (random >= 54f && random < 63f)
                k = 6;
            if (random >= 63f && random < 72f)
                k = 7;
            if (random >= 72f && random < 81f)
                k = 8;
            if (random >= 81f && random < 90f)
                k = 9;
            if (random >= 90f && random < 97f)
                k = 10;
            if (random >= 97f && random < 100f)
                k = 11;
            GameObject go = Instantiate(memberGenPrefab, new Vector3(272 + i * 163, 934, 0), Quaternion.identity) as GameObject;
            go.transform.parent = membersFolder.transform;
            members.Add(go);
            MemberHUD Yrt = go.GetComponent<MemberHUD>();
            Yrt.nameText.text = membersInfo.names[l];
            Yrt.profDetailsText.text = (ProfessionType)k + " = " + membersInfo.profDescription[k];
            Yrt.traitDetailsText.text = membersInfo.traitList[j] + " = " + membersInfo.tDescription[j];
            Yrt.trait.text = membersInfo.traitList[j];
            Yrt.profession = (ProfessionType)k;
            Yrt.profPrice.text = membersInfo.profPrice[k].ToString();
            Yrt.traitPrice.text = Yrt.trait.text + "(" + membersInfo.traitPrice[j].ToString() + ") + " + Yrt.profession + "(" + Yrt.profPrice.text + ") = " + (membersInfo.profPrice[k] + membersInfo.traitPrice[j]).ToString();
            Yrt.totalPrice.text = (membersInfo.profPrice[k] + membersInfo.traitPrice[j]).ToString();
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
        if (index > 13)
        {
            Debug.Log("Your number was too high");
            return;
        }
        GameObject go = new GameObject();
        if (index <= 5)
            go = Instantiate(megaHorPrefab, new Vector3(730, 992, 0), Quaternion.identity) as GameObject;
        else
            go = Instantiate(megaVerPrefab, new Vector3(920, 1015, 0), Quaternion.identity) as GameObject;
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

        if (index > 160)
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

    void Save()
    {

        BattleSystem data = new BattleSystem();
        data.modules = modules;
        data.members = members;
        data.megas = megas;
        SaveGame.Save<BattleSystem>("allData", data);

    }

    public void ResetTurns()
    {

        turn = 0;
        turnCounter.transform.GetComponent<TextMeshProUGUI>().text = turn.ToString();
    }

    IEnumerator AttackModule(GameObject slot)
    {

        yield return new WaitForSeconds(0.15f);

        if (slot.GetComponent<ItemSlot>().member != null)
        {
            if (slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health != 0)
                slot.GetComponent<ItemSlot>().member.GetComponent<MemberHUD>().health--;
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
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(131, 34, 1, 255);
                    yield break;
                default:
                    slot.GetComponent<ItemSlot>().member.transform.GetChild(22).GetComponent<TextMeshProUGUI>().color = new Color32(17, 205, 238, 255);
                    yield break;
            }
        }
    }
}
