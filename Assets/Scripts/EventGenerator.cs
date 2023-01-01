using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGenerator : MonoBehaviour
{
    public void GenerateEvent()
    {
        float number = Random.Range(0f, 100f);
        if (number < 40f)
            this.transform.GetChild(1).GetComponent<Text>().text = "Monster";
        if (number > 40f && number < 65f)
            this.transform.GetChild(1).GetComponent<Text>().text = "Shop";
        if (number > 65f)
            this.transform.GetChild(1).GetComponent<Text>().text = "Strange Event";
    }
}
