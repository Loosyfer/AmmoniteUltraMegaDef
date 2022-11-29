using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class EliminateMemberParent : MonoBehaviour
{

    public BattleSystem script;

    public void Awake()
    {
        script = GameObject.Find("/Battle System").GetComponent<BattleSystem>();


    }

    public void Eliminate()
    {
        script.members.Remove(transform.gameObject);
        Destroy(transform.gameObject);


    }

}
