using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2 : MonoBehaviour
{

    public Slider o2Bar;
    private float initialTime;

    public void ChangeMaximumO2(string s)
    {
        o2Bar.maxValue = int.Parse(s);
        o2Bar.value = 0;
    }

    public void Update()
    {
        
        o2Bar.value += Time.deltaTime - initialTime;
    }

}
