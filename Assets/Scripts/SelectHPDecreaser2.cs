using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHPDecreaser2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                if ((EventSystem.current.currentSelectedGameObject.transform.tag == "ShipHP"))
                    EventSystem.current.SetSelectedGameObject(gameObject);
            }
        }
    }
}
