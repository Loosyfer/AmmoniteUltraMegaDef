using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventType { NORMALENEMY, STRONGENEMY, EVENTENEMY, MARKET, HANGAR, RARE, ULTRARARE, EXPLORER }

[CreateAssetMenu(fileName = "EventExcel", menuName = "My Game/Event Excel")]
public class EventExcel : ScriptableObject
{
    private TextAsset textAssetData;

    [System.Serializable]
    public class Event
    {
        public string name;
        public string effect;
        public EventType type;
        public int chance;
    }

    [System.Serializable]
    public class EventList
    {
        public Event[] events;
    }

    public EventList myEvents = new EventList();

}
