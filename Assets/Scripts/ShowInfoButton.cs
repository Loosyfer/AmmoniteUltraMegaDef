using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoButton : MonoBehaviour
{

    public bool showInfo;

    private void Awake()
    {
        showInfo = true;
    }

    public void switchShowInfo()
    {
        showInfo = !showInfo;
        if (showInfo)
            this.GetComponent<Image>().color = new Color32(13, 255, 0, 255);
        else
            this.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }

}
