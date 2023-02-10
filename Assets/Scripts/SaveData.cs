using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }

        set
        {
            _current = value;
        }
    }

    public List<float> posX = new List<float>();
    public List<float> posY = new List<float>();
    public List<float> posZ = new List<float>();
    public List<int> id = new List<int>();
    public List<int> req = new List<int>();
    public List<int> sideE = new List<int>();
    public List<int> sEffectorDefect = new List<int>();
    public List<int> sEffectSide = new List<int>();
    public List<float> memPosX = new List<float>();
    public List<float> memPosY = new List<float>();
    public List<float> memPosZ = new List<float>();
    public List<int> memId = new List<int>();
    public List<int> memId2 = new List<int>();
    public List<int> memProfessionId = new List<int>();
    public List<int> memHealth = new List<int>();
    public List<float> memPerformance = new List<float>();
}
