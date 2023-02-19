using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemiesExcel", menuName = "My Game/Enemies Excel")]
public class EnemiesExcel : ScriptableObject
{
    private TextAsset textAssetData;

    [System.Serializable]
    public class Enemy
    {
        public Sprite icon;
        public string name;
        public int health;
        public int dPT;
        public string effect;
        public string flavour;
        public int level;
        public bool type;
        public int crewDMG;
    }

    [System.Serializable]
    public class EnemiesList
    {
        public Enemy[] enemies;
    }

    public EnemiesList myEnemies = new EnemiesList();
}
