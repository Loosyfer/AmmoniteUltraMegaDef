using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseHP : MonoBehaviour
{
    public Slider enemyHP;
    public float inputValue;

    public void ReadStringInput(string s)
    {
        inputValue = float.Parse(s);
        enemyHP.value -= (inputValue/3000);
        Debug.Log("El valor es" + inputValue);
    }
}
