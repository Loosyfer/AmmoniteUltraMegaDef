using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGame : MonoBehaviour
{
    public BattleSystem system;

    public void Save()
    {
        system.OnSave();
    }

    public void Load()
    {
        system.OnLoad();
    }
}
