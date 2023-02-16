using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGenerator : MonoBehaviour
{
    public void GenerateEvent()
    {
        float number = Random.Range(0f, 100f);
        if (number < 30f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Normal Enemy";
        if (number >= 30f && number < 40f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Strong Enemy";
        if (number >= 40f && number < 58f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Market";
        if (number >= 58f && number < 75f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Hangar";
        if (number >= 75f && number < 92f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Rare Event";
        if (number >= 92f && number < 98f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Event Enemy";
        if (number >= 98f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Ultra Rare Event";
    }
}
