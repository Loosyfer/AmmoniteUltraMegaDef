using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

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
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        while (activeSelf)
        {


            if (loopNumber == 0)
            {
                
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

            for (int i = 0; i < 7; i++)
            {
                GameObject goo = Instantiate(moduleSlotPrefab, new Vector3(760 + (i * 140), 343 + (79 * j), 0), Quaternion.identity) as GameObject;
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

            for (int i = 0; i < 7; i++)
            {
                GameObject goo = Instantiate(slotButtonPrefab, new Vector3(730 + (i * 27.77f), 16.8f + (22.17f * j), 0), Quaternion.identity) as GameObject;
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
        GameObject canvas = GameObject.Find("/Malla");
        GameObject modulesFolder = canvas.transform.GetChild(27).gameObject;
        int k = Random.Range(0, 11);
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
                break;
            case "1":
                Yrt.req.text = modInfo.randomReq[k].ToString();
                break;
            default:
                Yrt.req.text = modInfo.req[index];
                break;
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
            stackeos[0]++;
            canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[0];
        }
        if (Yrt.type == (ModuleType)1)
        { 
            imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
            stackeos[1]++;
            canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[1];
        }
        if (Yrt.type == (ModuleType)2)
        {
            imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);
            stackeos[2]++;
            canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[2];
        }
        if (Yrt.type == (ModuleType)3)
        {
            stackeos[3]++;
            canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[3];
        }
        if (Yrt.type == (ModuleType)4)
        {
            imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);
            stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[4];
        }
        if (Yrt.type == (ModuleType)5)
        {
            imagen.color = new Color(0.9843f, 1, 0.2196f, 1);
            stackeos[4]++;
            canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[4];
        }
    }

    public void GenerateMembers(string s)
    {
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
        GameObject go = Instantiate(memberGenPrefab, new Vector3(908, 1025, 0), Quaternion.identity) as GameObject;
        go.transform.parent = membersFolder.transform;
        MemberHUD Yrt = go.GetComponent<MemberHUD>();
        members.Add(go);
        Yrt.nameText.text = membersInfo.names[l];
        Yrt.profDetailsText.text = (ProfessionType)index1 + " = " + membersInfo.profDescription[index1];
        Yrt.traitDetailsText.text = membersInfo.traitList[index2] + " = " + membersInfo.tDescription[index2];
        Yrt.trait.text = membersInfo.traitList[index2];
        Yrt.profession = (ProfessionType)index1;
        Yrt.profPrice.text = membersInfo.profPrice[index1].ToString();
        Yrt.traitPrice.text = membersInfo.traitPrice[index2].ToString();
        Yrt.totalPrice.text = (membersInfo.profPrice[index1] + membersInfo.traitPrice[index2]).ToString();
        Yrt.performance = 50;
        mStackeos[index1]++;
        canvas.transform.GetChild(30).GetChild(index1 + 5).GetChild(0).GetComponent<TMP_Text>().text = "x" + mStackeos[index1];  

    }

    public void Generate(string s)
    {
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
            int k = Random.Range(0, 11);
            GameObject go = Instantiate(moduleGenPrefab, new Vector3(288 + i * 155, 960, 0), Quaternion.identity) as GameObject;
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
                    break;
                case "1":
                    Yrt.req.text = modInfo.randomReq[k].ToString();
                    break;
                default:
                    Yrt.req.text = modInfo.req[j];
                    break;
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
                stackeos[0]++;
                canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[0];
            }
            if (Yrt.type == (ModuleType)1)
            {
                imagen.color = new Color(0.9333f, 0.4862f, 0.4235f, 1);
                stackeos[1]++;
                canvas.transform.GetChild(30).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[1];
            }
            if (Yrt.type == (ModuleType)2)
            {
                imagen.color = new Color(0.55f, 0.7254f, 0.8784f, 1);
                stackeos[2]++;
                canvas.transform.GetChild(30).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[2];
            }
            if (Yrt.type == (ModuleType)3)
            {
                stackeos[3]++;
                canvas.transform.GetChild(30).GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[3];
            }
            if (Yrt.type == (ModuleType)4)
            {
                imagen.color = new Color(0.99f, 0.84f, 0.4f, 1);
                stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[4];
            }
            if (Yrt.type == (ModuleType)5)
            {
                imagen.color = new Color(0.9843f, 1, 0.2196f, 1);
                stackeos[4]++;
                canvas.transform.GetChild(30).GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[4];
            }
        }

        for (int i = 0; i < cyclelength; i++)
        {
            int j = Random.Range(0, 187);
            int l = Random.Range(0, membersInfo.names.Length);
            int k = Random.Range(0, 12);
            GameObject go = Instantiate(memberGenPrefab, new Vector3(288 + i * 155, 1025, 0), Quaternion.identity) as GameObject;
            go.transform.parent = membersFolder.transform;
            members.Add(go);
            MemberHUD Yrt = go.GetComponent<MemberHUD>();
            Yrt.nameText.text = membersInfo.names[l];
            Yrt.profDetailsText.text = (ProfessionType)k + " = " + membersInfo.profDescription[k];
            Yrt.traitDetailsText.text = membersInfo.traitList[j] + " = " + membersInfo.tDescription[j];
            Yrt.trait.text = membersInfo.traitList[j];
            Yrt.profession = (ProfessionType)k;
            Yrt.profPrice.text = membersInfo.profPrice[k].ToString();
            Yrt.traitPrice.text = membersInfo.traitPrice[j].ToString();
            Yrt.totalPrice.text = (membersInfo.profPrice[k] + membersInfo.traitPrice[j]).ToString();
            Yrt.performance = 50;
            SpriteRenderer imagen = go.GetComponent<SpriteRenderer>();
            mStackeos[k]++;
            canvas.transform.GetChild(30).GetChild(k + 5).GetChild(0).GetComponent<TMP_Text>().text = "x" + mStackeos[k];

        }
    }

    public void GenerateMegas(string s)
    {
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
            go = Instantiate(megaHorPrefab, new Vector3(768, 958, 0), Quaternion.identity) as GameObject;
        else
            go = Instantiate(megaVerPrefab, new Vector3(768, 958, 0), Quaternion.identity) as GameObject;
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
        canvas.transform.GetChild(30).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "x" + stackeos[0];
        Image imagen = go.transform.GetComponent<Image>();
        imagen.color = new Color(0.4078f, 0.7294f, 0.5411f, 1);
    }
}
