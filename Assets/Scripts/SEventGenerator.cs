using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEventGenerator : MonoBehaviour
{

    public StrangeEvents strangeEvents;

    public void GenerateStrangeEvent()
    {
        int number = Random.Range(0, strangeEvents.strangeEvents.Length);
            this.transform.GetChild(1).GetComponent<Text>().text = strangeEvents.strangeEvents[number];
    }
}
