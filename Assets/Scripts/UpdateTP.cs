using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTP : MonoBehaviour
{
    public BattleSystem script;
    public Slider slider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (script.totalPerformance / 100);
        Image background = slider.transform.GetChild(0).GetComponent<Image>();
        Image fill = slider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        if (slider.value < 0.25)
        {
            background.color = new Color(1, 0, 0, 1);
            fill.color = new Color(1, 0.5f, 0, 1);
        }
        if (slider.value >= 0.25 && slider.value < 0.5)
        {
            background.color = new Color(0, 0.2f, 0.7f, 1);
            fill.color = new Color(0.3f, 0.5f, 1, 1);
        }
        if (slider.value >= 0.5 && slider.value < 0.75)
        {
            background.color = new Color(0.2f, 0.9f, 0.65f, 1);
            fill.color = new Color(0.2f, 0.8f, 0.8f, 1);
        }
        if (slider.value >= 0.75 && slider.value < 1)
        {
            background.color = new Color(0, 1, 0, 1);
            fill.color = new Color(0.23f, 0.89f, 0.48f, 1);
        }
        if (slider.value == 1)
        {
            background.color = new Color(1, 1, 0, 1);
            fill.color = new Color(1, 1, 0, 1);
        }
    }
}
