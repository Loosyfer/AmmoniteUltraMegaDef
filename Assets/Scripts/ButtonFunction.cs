using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{

    public int number;
    public bool activated;

    public void ChangeColor()
    {
        if (activated)
        {
            this.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            activated = false;
        }
        else
        {
            this.GetComponent<Image>().color = new Color32(60, 200, 64, 255);
            activated = true;
        }
    }

}
