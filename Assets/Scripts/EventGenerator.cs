using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGenerator : MonoBehaviour
{
    public void GenerateEvent()
    {
        float number = Random.Range(0f, 100f);
        if (number < 25f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Normal Enemy";
        if (number >= 25f && number < 35f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Strong Enemy";
        if (number >= 35f && number < 52f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Recruitment Center";
        if (number >= 52f && number < 69f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Submarine Factory";
        if (number >= 69f && number < 92f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Rare Event";
        if (number >= 92f)
            this.transform.GetChild(2).GetComponent<Text>().text = "Ultra Rare Event";
    }
}
