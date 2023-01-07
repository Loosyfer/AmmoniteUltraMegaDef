using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabSwitcher : MonoBehaviour
{

    public GameObject ShipHP;
    public GameObject EnemyHP;


    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(ShipHP);
            else
            {
                if ((EventSystem.current.currentSelectedGameObject.transform.tag == "ShipHP"))
                    EventSystem.current.SetSelectedGameObject(EnemyHP);
                else
                    EventSystem.current.SetSelectedGameObject(ShipHP);
            }
        }*/
    }
}
