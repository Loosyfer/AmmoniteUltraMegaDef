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
    public List<int> objectListId = new List<int>();
    public ItemsExcel itemsExcel;
    private string[] itemsData;
    private System.Random randomItems = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] all = Resources.LoadAll<Sprite>("Objects/Item_Icons");
        for (int i = 0; i < 154; i++)
        {
            objects.sprites[i] = all[i];
        }
        Sprite[] all2 = Resources.LoadAll<Sprite>("Objects/Item_Icons_2");
        for (int i = 0; i < 56; i++)
        {
            objects.sprites[i + 154] = all2[i];
        }

        itemsData = Resources.Load<TextAsset>("Excel/Items").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = (itemsData.Length / 5) - 1;
        itemsExcel.myItems.items = new ItemsExcel.Item[tableSize];
        for (int i = 0; i < tableSize; i++)
        {
            itemsExcel.myItems.items[i] = new ItemsExcel.Item();
            itemsExcel.myItems.items[i].name = itemsData[(5 * (i + 1))];
            itemsExcel.myItems.items[i].effect = itemsData[(5 * (i + 1)) + 1];
            itemsExcel.myItems.items[i].effect = itemsExcel.myItems.items[i].effect.Replace("*", ",");
            itemsExcel.myItems.items[i].type = itemsData[(5 * (i + 1)) + 2];
        }
    }

    public void SpawnObject()
    {
        int i = randomItems.Next(0, 210);
        while (itemsExcel.myItems.items[i].type != "")
            i = randomItems.Next(0, 210);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618 , 861 , 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objeto.GetComponent<ObjectHUD>().name = itemsExcel.myItems.items[i].name;
        objeto.GetComponent<ObjectHUD>().description = itemsExcel.myItems.items[i].effect;
        objectList.Add(objeto);
        objectListId.Add(i);
    }

    public void SpawnObjectWArg(string s)
    {
        int i = int.Parse(s);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618, 861, 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objeto.GetComponent<ObjectHUD>().name = itemsExcel.myItems.items[i].name;
        objeto.GetComponent<ObjectHUD>().description = itemsExcel.myItems.items[i].effect;
        objectList.Add(objeto);
        objectListId.Add(i);
    }

    public void SpawnObjectWArg2(string s, float x, float y, float z)
    {
        int i = int.Parse(s);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618, 861, 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objeto.GetComponent<ObjectHUD>().name = itemsExcel.myItems.items[i].name;
        objeto.GetComponent<ObjectHUD>().description = itemsExcel.myItems.items[i].effect;
        objectList.Add(objeto);
        objectListId.Add(i);
        objeto.transform.position = new Vector3(x, y, z);
    }
}
