using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGenerator : MonoBehaviour
{
    public void GenerateEvent()
    {
        float number = Random.Range(0f, 100f);
        if (number < 31f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Normal Enemy";
        if (number >= 31f && number < 41f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Strong Enemy";
        if (number >= 41f && number < 58f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Recruitment Center";
        if (number >= 58f && number < 75f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Submarine Factory";
        if (number >= 75f && number < 95f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Rare Event";
        if (number >= 95f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Ultra Rare Event";
    }
}
