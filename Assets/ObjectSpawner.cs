using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public GameObject malla;

    public void Spawner(string s)
    {
        GameObject go = Instantiate(objectPrefab, new Vector3(1450, 882, 0), Quaternion.identity) as GameObject;
        go.GetComponent<Text>().text = s;
        go.transform.parent = malla.transform;
    }
}
