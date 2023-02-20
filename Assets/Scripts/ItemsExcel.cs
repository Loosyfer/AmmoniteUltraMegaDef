using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsExcel", menuName = "My Game/Items Excel")]
public class ItemsExcel : ScriptableObject
{
    private TextAsset textAssetData;

    [System.Serializable]
    public class Item
    {
        public string name;
        public string effect;
        public string type;
    }

    [System.Serializable]
    public class ItemList
    {
        public Item[] items;
    }

    public ItemList myItems = new ItemList();

}
