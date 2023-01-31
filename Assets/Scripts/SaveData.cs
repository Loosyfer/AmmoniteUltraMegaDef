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
}
