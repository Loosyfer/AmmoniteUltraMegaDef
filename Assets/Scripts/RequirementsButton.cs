using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsButton : MonoBehaviour
{
    public bool state;

    public void ReqOnOff()
    {
        state = !state;
        if (state)
            this.transform.GetComponent<Image>().color = new Color(0, 1, 0, 1);
        else
            this.transform.GetComponent<Image>().color = new Color(1, 0, 0, 1);
    }
}
