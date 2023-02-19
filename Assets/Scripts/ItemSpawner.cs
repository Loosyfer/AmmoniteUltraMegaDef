using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawner : MonoBehaviour
{

    public Objects objects;
    public GameObject objectPrefab;
    public List<GameObject> objectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] all = Resources.LoadAll<Sprite>("Objects/Item_Icons");
        for (int i = 0; i < 166; i++)
        {
            objects.sprites[i] = all[i];
        }
    }

    public void SpawnObject()
    {
        int i = Random.Range(0, 165);
        GameObject objeto = Instantiate(objectPrefab, new Vector3(618 , 197 , 0), Quaternion.identity) as GameObject;
        objeto.GetComponent<ObjectHUD>().name = objects.names[i];
        objeto.GetComponent<ObjectHUD>().description = objects.description[i];
        objeto.GetComponent<Image>().sprite = objects.sprites[i];
        objectList.Add(objeto);
    }
}
