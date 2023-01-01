using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMonsterName : MonoBehaviour
{

    public GameObject monster;
    public Text text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

                text.text = monster.GetComponent<MonsterHUD>().name;

    }
}
