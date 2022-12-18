using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaTypeHolder : MonoBehaviour
{
    public bool offensive;
    public bool defensive;
    public bool scientific;
    public bool normal;
    public List<int> megasSelected = new List<int>();
    public MegamodulesInfo megaInfo;
    public BattleSystem script;
    public GameObject megaHorPrefab;
    public GameObject megaVerPrefab;


    void Start()
    {
        offensive = false;
        defensive = false;
        scientific = false;
        normal = false;
    }

    public void GenerateMegas()
    {
        offensive = this.transform.GetChild(1).GetComponent<NormalButton>().pushed;
        defensive = this.transform.GetChild(2).GetComponent<NormalButton>().pushed;
        scientific = this.transform.GetChild(3).GetComponent<NormalButton>().pushed;
        normal = this.transform.GetChild(4).GetComponent<NormalButton>().pushed;

        if ((offensive && defensive && scientific) || (offensive && defensive && normal) || (offensive && scientific && normal) || (defensive && scientific && normal))
            return;
        if ((!offensive && !defensive && !scientific && !normal))
            return;

         for (int i = 0; i < 13; i++)
         {
             if (offensive)
             {
                 if (megaInfo.moduleType[i] == (ModuleType)1)
                     megasSelected.Add(i);
             }
             if (defensive)
             {
                if (megaInfo.moduleType[i] == (ModuleType)2)
                {
                    megasSelected.Add(i);
                    Debug.Log("i es " + i);
                }
             }
             if (scientific)
             {
                 if (megaInfo.moduleType[i] == (ModuleType)3)
                     megasSelected.Add(i);
             }
             if (normal)
             {
                 if (megaInfo.moduleType[i] == (ModuleType)4)
                     megasSelected.Add(i);
             }
         }

        int random = Random.Range(0, megasSelected.Count);
        int index = megasSelected[random];
        megasSelected = new List<int>();
        GameObject canvas = GameObject.Find("/Malla");
        GameObject go = new GameObject();
        if (index <= 5)
            go = Instantiate(megaHorPrefab, new Vector3(768, 958, -1), Quaternion.identity) as GameObject;
            else
            go = Instantiate(megaVerPrefab, new Vector3(768, 958, -1), Quaternion.identity) as GameObject;
        go.transform.parent = canvas.transform;
        if (index <= 5)
        {
            MegaHUD ob = go.GetComponent<MegaHUD>();
            ob.detailsText.text = megaInfo.moduleDetails[index];
            ob.type = megaInfo.moduleType[index];
            ob.nameText.text = megaInfo.names[index];
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
        script.megas.Add(go);
    }
}
