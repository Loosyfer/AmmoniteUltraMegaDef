using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class DestroyModule : MonoBehaviour
{

    private BattleSystem script;
    private GameObject memberorModule;

    public void Awake()
    {
        script = GameObject.Find("/Battle System").GetComponent<BattleSystem>();


    }

    public void Eliminate()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
        {
            memberorModule = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
            script.modules.Remove(memberorModule);
            Destroy(memberorModule);
        }
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            memberorModule = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
            script.members.Remove(memberorModule);
            Destroy(memberorModule);
        }

    }

}
