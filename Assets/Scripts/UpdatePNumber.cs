using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePNumber : MonoBehaviour
{
    void Update()
    {

        int value = (int)(transform.parent.GetComponent<MemberHUD>().performance);
        TextMeshProUGUI texto = transform.GetComponent<TextMeshProUGUI>();
        texto.text = value.ToString();
        if (value < 20)
        {
            texto.color = new Color(0.783f, 0.18f, 0.077f, 1);
        }
        if (value >= 20 && value < 40)
        {
            texto.color = new Color(0.91f, 0.61f, 0.13f, 1);
        }
        if (value >= 40 && value < 60)
        {
            texto.color = new Color(0.3607843f, 0.9490196f, 0.5333334f, 1);
        }
        if (value >= 60 && value < 80)
        {
            texto.color = new Color(0.36f, 0.95f, 0.90f, 1);
        }
        if (value >= 80 && value < 100)
        {
            texto.color = new Color(0.1137255f, 0.7960784f, 0.9764706f, 1);
        }
        if (value == 100)
        {
            texto.color = new Color(1, 0.9333333f, 0.3372549f, 1);
        }
    }
}
