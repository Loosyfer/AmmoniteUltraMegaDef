using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFuel : MonoBehaviour
{

    private int fuel;

    private void Awake()
    {
        fuel = 8;
    }

    public void UpdateF(string s)
    {
        fuel = int.Parse(s) + fuel;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = fuel.ToString();
    }
}
