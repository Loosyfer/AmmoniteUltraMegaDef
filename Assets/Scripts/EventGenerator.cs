using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGenerator : MonoBehaviour
{
    public void GenerateEvent()
    {
        float number = Random.Range(0f, 100f);
        if (number < 33f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Normal Enemy";
        if (number >= 33f && number < 43f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Strong Enemy";
        if (number >= 43f && number < 62f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Market";
        if (number >= 62f && number < 81f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Hangar";
        if (number >= 81f && number < 97f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Rare Event";
        if (number >= 97f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Ultra Rare Event";
    }
}
