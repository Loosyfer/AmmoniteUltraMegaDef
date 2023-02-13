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
            this.transform.GetComponent<Image>().color = new Color32(156, 247, 255, 255);
        else
            this.transform.GetComponent<Image>().color = new Color32(224, 136, 153, 255);
    }
}
