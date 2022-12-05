using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSlot : MonoBehaviour
{

    public bool activated;

    private void Start()
    {
        if (!activated)
        {
            this.transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            this.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void Activate()
    {
        if (this.transform.GetComponent<Image>().raycastTarget == true)
        {
            this.transform.GetComponent<Image>().raycastTarget = false;
            this.transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            this.transform.GetComponent<Image>().raycastTarget = true;
            this.transform.GetComponent<Image>().color = new Color32(0, 0, 0, 90);
        }
    }

}
