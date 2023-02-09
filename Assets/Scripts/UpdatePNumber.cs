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
        if (value < 10)
        {
            texto.color = new Color(0.5f, 0.1f, 0.02f, 1);
        }
        if (value >= 10 && value < 20)
        {
            texto.color = new Color(0.783f, 0.18f, 0.077f, 1);
        }
        if (value >= 20 && value < 30)
        {
            texto.color = new Color(0.95f, 0.5f, 0.13f, 1);
        }
        if (value >= 30 && value < 40)
        {
            texto.color = new Color(0.85f, 0.9f, 0.37f, 1);
        }
        if (value >= 40 && value < 50)
        {
            texto.color = new Color(0.35f, 0.9490196f, 0.4f, 1);
        }
        if (value >= 50 && value < 60)
        {
            texto.color = new Color(0.18f, 0.94f, 0.82f, 1);
        }
        if (value >= 60 && value < 70)
        {
            texto.color = new Color(0.1137255f, 0.8560784f, 0.9764706f, 1);
        }
        if (value >= 70 && value < 80)
        {
            texto.color = new Color(0.37f, 0.49f, 1, 1);
        }
        if (value >= 80 && value < 90)
        {
            texto.color = new Color(0.62f, 0.42f, 1, 1);
        }
        if (value >= 90 && value < 100)
        {
            texto.color = new Color(0.98f, 0.447f, 1, 1);
        }
        if (value >= 100)
        {
            texto.color = new Color(1, 0.9333333f, 0.3372549f, 1);
        }
    }
}
