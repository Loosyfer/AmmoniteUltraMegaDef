using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        {
            this.GetComponent<Image>().color = new Color32(156, 247, 255, 255);
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Info On";
        }

        else
        {
            this.GetComponent<Image>().color = new Color32(224, 136, 153, 255);
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Info Off";
        }
    }

}
