using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ModExcel", menuName = "My Game/Mod Excel")]
public class ModExcel : ScriptableObject
{
    private TextAsset textAssetData;

    [System.Serializable]
    public class Module
    {
        public string name;
        public string effect;
        public string requirement;
        public ModuleType type;
        public int price;
    }

    [System.Serializable]
    public class ModuleList
    {
        public Module[] modules;
    }

    public ModuleList myModules = new ModuleList();

    void Awake()
    {
        Debug.Log("HOLAMUBUENACOMOESTAMOS");
        string[] data = Resources.Load<TextAsset>("Modules/Modules").text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = (data.Length / 6) - 1;
        myModules.modules = new Module[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            myModules.modules[i] = new Module();
            myModules.modules[i].name = data[(6 * (i + 1)) + 1];
            Debug.Log(myModules.modules[i].name);
            myModules.modules[i].effect = data[(6 * (i + 1)) + 2];
            switch (data[(6 * (i + 1)) + 3])
            {
                case "Organic A":
                    myModules.modules[i].type = (ModuleType)0;
                    break;
                case "Offensive":
                    myModules.modules[i].type = (ModuleType)1;
                    break;
                case "Defensive":
                    myModules.modules[i].type = (ModuleType)2;
                    break;
                case "Scientific":
                    myModules.modules[i].type = (ModuleType)3;
                    break;
                case "Normal":
                    myModules.modules[i].type = (ModuleType)4;
                    break;
                case "Legendary":
                    myModules.modules[i].type = (ModuleType)5;
                    break;
            }
            myModules.modules[i].requirement = data[(6 * (i + 1)) + 4];
            myModules.modules[i].price = int.Parse(data[(6 * (i + 1)) + 5]);

        }
    }
}
