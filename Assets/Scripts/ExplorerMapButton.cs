using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerMapButton : MonoBehaviour
{

    public void ExplorerAvaliable()
    {
        if (this.transform.parent.transform.GetChild(3).gameObject.activeSelf)
            this.transform.parent.transform.GetChild(3).gameObject.SetActive(false);
        else
            this.transform.parent.transform.GetChild(3).gameObject.SetActive(true);
    }

}
