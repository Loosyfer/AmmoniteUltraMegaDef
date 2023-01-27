using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateP : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = (transform.parent.GetComponent<MemberHUD>().performance);
        Image fill = slider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        if (slider.value < 20)
        {
            fill.color = new Color(0.783f, 0.18f, 0.077f, 1);
        }
        if (slider.value >= 20 && slider.value < 40)
        {
            fill.color = new Color(0.91f, 0.61f, 0.13f, 1);
        }
        if (slider.value >= 40 && slider.value < 60)
        {
            fill.color = new Color(0.3607843f, 0.9490196f, 0.5333334f, 1);
        }
        if (slider.value >= 60 && slider.value < 80)
        {
            fill.color = new Color(0.36f, 0.95f, 0.90f, 1);
        }
        if (slider.value >= 80 && slider.value < 100)
        {
            fill.color = new Color(0.1137255f, 0.7960784f, 0.9764706f, 1);
        }
        if (slider.value == 100)
        {
            fill.color = new Color(1, 0.9333333f, 0.3372549f, 1);
        }
    }
}
