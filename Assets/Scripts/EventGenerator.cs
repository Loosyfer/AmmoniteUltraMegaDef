using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EventGenerator : MonoBehaviour
{

    private int numOfEvents = 8;
    public string eventType;
    public string eventName;
    public string eventEffect;
    public EventExcel eventsExcel;
    public List<int> eventEnemiesId = new List<int>();
    public List<int> rareEventsId = new List<int>();
    public List<int> ultraRareEventsId = new List<int>();
    public List<int> explorerEventsId = new List<int>();
    string[] eventsData;
    int[] chances;
    int[] chancesAccumulative;
    int tableSize;
    public Text namePanel;
    public TextMeshProUGUI effectPanel;
    private System.Random eventGenerator = new System.Random();

    private void Start()
    {
        eventsData = Resources.Load<TextAsset>("Excel/Events").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        tableSize = (eventsData.Length / 4) - 1;
        eventsExcel.myEvents.events = new EventExcel.Event[tableSize];
        chances = new int[numOfEvents - 1];
        chancesAccumulative = new int[numOfEvents - 1];

        for (int j = 0; j < numOfEvents - 1; j++)
        {
            chances[j] = int.Parse(eventsData[(4 * (j + 1)) + 3]);
        }

        for (int i = 0; i < tableSize; i++)
        {
            switch (eventsData[(4 * (i + 1)) + 2])
                {
                case "Eventenemy":
                    eventEnemiesId.Add(i);
                    break;
                case "Rare":
                    rareEventsId.Add(i);
                    break;
                case "Ultrarare":
                    ultraRareEventsId.Add(i);
                    break;
                case "Explorer":
                    explorerEventsId.Add(i);

                    break;
            }
        }

        chancesAccumulative[0] = chances[0];
        for (int i = 1; i < numOfEvents; i++)
        {
            chancesAccumulative[i] = chancesAccumulative[i - 1] + chances[i];
        }
        
    }

    public void GenerateEvent()
    {
        int r = eventGenerator.Next(0, 100);
        int l;
        switch (r)
        {
            case int n when (n <= chancesAccumulative[0]):
                eventType = eventsData[4];
                eventName = "";
                eventEffect = "";
                break;
            case int n when (n > chancesAccumulative[0] && n <= chancesAccumulative[1]):
                eventType = eventsData[8];
                eventName = "";
                eventEffect = "";
                break;
            case int n when (n > chancesAccumulative[1] && n <= chancesAccumulative[2]):
                eventType = eventsData[12];
                l = UnityEngine.Random.Range(0, eventEnemiesId.Count);
                eventName = eventsData[4 * (eventEnemiesId[l] + 1)];
                eventEffect = eventsData[4 * (eventEnemiesId[l] + 1) + 1];
                break;
            case int n when (n > chancesAccumulative[2] && n <= chancesAccumulative[3]):
                eventType = eventsData[16];
                eventName = "";
                eventEffect = "";
                break;
            case int n when (n > chancesAccumulative[3] && n <= chancesAccumulative[4]):
                eventType = eventsData[20];
                eventName = "";
                eventEffect = "";
                break;
            case int n when (n > chancesAccumulative[4] && n <= chancesAccumulative[5]):
                eventType = eventsData[24];
                l = UnityEngine.Random.Range(0, rareEventsId.Count);
                eventName = eventsData[4 * (rareEventsId[l] + 1)];
                eventEffect = eventsData[4 * (rareEventsId[l] + 1) + 1];
                break;
            case int n when (n > chancesAccumulative[5] && n <= chancesAccumulative[6]):
                eventType = eventsData[28];
                l = UnityEngine.Random.Range(0, ultraRareEventsId.Count);
                eventName = eventsData[4 * (ultraRareEventsId[l] + 1)];
                eventEffect = eventsData[4 * (ultraRareEventsId[l] + 1) + 1];
                break;
            case int n when (n > chancesAccumulative[6] && n <= chancesAccumulative[7]):
                eventType = eventsData[32];
                l = UnityEngine.Random.Range(0, explorerEventsId.Count);
                eventName = eventsData[4 * (explorerEventsId[l] + 1)];
                eventEffect = eventsData[4 * (explorerEventsId[l] + 1) + 1];
                break;
        }

        this.transform.GetChild(2).GetComponent<Text>().text = eventType;
        namePanel.text = eventName;
        effectPanel.text = eventEffect;
    }
}
