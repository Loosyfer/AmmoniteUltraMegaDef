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

}
