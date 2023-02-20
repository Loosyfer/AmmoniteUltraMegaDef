using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{

    public Objects objects;
    public GameObject objectPrefab;
    public ItemSpawner itemSpawner;

    void Start()
    {
        Sprite[] all = Resources.LoadAll<Sprite>("Objects/Item_Icons");
        for (int i = 0; i < 166; i++)
        {
            objects.sprites[i] = all[i];
        }
    }

    public void Spawner(string s)
    {
        if (int.TryParse(s, out int n) && n > 0 && n < 217)
        {
            itemSpawner.SpawnObjectWArg(n.ToString());
        }
    }
}
