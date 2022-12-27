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
        slider.value = (script.totalPerformance);
        Image background = slider.transform.GetChild(0).GetComponent<Image>();
        Image fill = slider.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        if (slider.value < 25)
        {
            background.color = new Color(0.3098f, 0.3098f, 0.3098f, 1);
            fill.color = new Color(0.6941177f, 0.3333333f, 0.172549f, 1);
        }
        if (slider.value >= 25 && slider.value < 49)
        {
            background.color = new Color(0.3098f, 0.3098f, 0.3098f, 1);
            fill.color = new Color(0.6862745f, 0.5529412f, 0.1843137f, 1);
        }
        if (slider.value >= 49 && slider.value < 75)
        {
            background.color = new Color(0.3098f, 0.3098f, 0.3098f, 1);
            fill.color = new Color(0.3607843f, 0.9490196f, 0.5333334f, 1);
        }
        if (slider.value >= 75 && slider.value < 100)
        {
            background.color = new Color(0.3098f, 0.3098f, 0.3098f, 1);
            fill.color = new Color(0.1137255f, 0.7960784f, 0.9764706f, 1);
        }
        if (slider.value == 100)
        {
            background.color = new Color(1, 1, 0, 1);
            fill.color = new Color(1, 0.9333333f, 0.3372549f, 1);
        }
        this.transform.GetChild(6).GetComponent<Text>().text = slider.value + " %";
    }
}
