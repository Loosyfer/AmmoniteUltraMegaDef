using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class Destroy : MonoBehaviour
{

    public BattleSystem script;
    private GameObject memberorModule;

    public void Eliminate()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Module")
        {
            memberorModule = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
            script.modules.Remove(memberorModule);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
            Destroy(memberorModule);
        }
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null && transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
        {
            memberorModule = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember;
            script.members.Remove(memberorModule);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
            Destroy(memberorModule);
        }

    }

}
