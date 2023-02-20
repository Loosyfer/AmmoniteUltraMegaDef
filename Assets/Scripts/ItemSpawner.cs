using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemSpawner : MonoBehaviour
{

    public Objects objects;
    public GameObject objectPrefab;
    public List<GameObject> objectList = new List<GameObject>();
    public ItemsExcel itemsExcel;
    private string[] itemsData;

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] all = Resources.LoadAll<Sprite>("Objects/Item_Icons");
        for (int i = 0; i < 166; i++)
        {
            objects.sprites[i] = all[i];
        }
        Sprite[] all2 = Resources.LoadAll<Sprite>("Objects/Item_Icons_2");
        for (int i = 0; i < 51; i++)
        {
            objects.sprites[i + 166] = all2[i];
        }

        itemsData = Resources.Load<TextAsset>("Excel/Items").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = (itemsData.Length / 5) - 1;
        itemsExcel.myItems.items = new ItemsExcel.Item[tableSize];
        for (int i = 0; i < tableSize; i++)
        {
            itemsExcel.myItems.items[i] = new ItemsExcel.Item();
            itemsExcel.myItems.items[i].name = itemsData[(5 * (i + 1))];
            itemsExcel.myItems.items[i].effect = itemsData[(5 * (i + 1)) + 1];
            itemsExcel.myItems.items[i].type = itemsData[(5 * (i + 1)) + 2];
        }
    }

    public void SpawnObject()
    {
        int i = UnityEngine.Random.Range(0, 217);
        while (itemsExcel.myItems.items[i].type != "")
            i = UnityEngine.Random.Range(0, 217);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618 , 197 , 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objeto.GetComponent<ObjectHUD>().name = itemsExcel.myItems.items[i].name;
        objeto.GetComponent<ObjectHUD>().description = itemsExcel.myItems.items[i].effect;
        objectList.Add(objeto);
    }

    public void SpawnObjectWArg(string s)
    {
        int i = int.Parse(s);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618, 197, 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objeto.GetComponent<ObjectHUD>().name = itemsExcel.myItems.items[i].name;
        objeto.GetComponent<ObjectHUD>().description = itemsExcel.myItems.items[i].effect;
        objectList.Add(objeto);
    }
}
