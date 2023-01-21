using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SEventGenerator : MonoBehaviour
{

    public StrangeEvents strangeEvents;

    public void GenerateRareEvent()
    {
        int number = Random.Range(0, strangeEvents.strangeEvents.Length);
        this.transform.GetChild(2).GetComponent<Text>().text = strangeEvents.strangeEvents[number];
        this.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = strangeEvents.sEventsDescription[number];

    }

    public void GenerateUltraRareEvent()
    {
        int number = Random.Range(0, strangeEvents.ultraRareEvents.Length);
        this.transform.parent.transform.GetChild(2).GetComponent<Text>().text = strangeEvents.ultraRareEvents[number];
        this.transform.parent.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = strangeEvents.uRareEventsDescription[number];
    }

    public void GenerateExplorerEvent()
    {
        int number = Random.Range(0, strangeEvents.explorerEvents.Length);
        this.transform.parent.transform.GetChild(2).GetComponent<Text>().text = strangeEvents.explorerEvents[number];
        this.transform.parent.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = strangeEvents.explorerEventsDescription[number];
    }
}
