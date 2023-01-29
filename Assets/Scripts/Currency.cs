using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int money = 0;

    public void ChangeCurrency(string s)
    {
        if (int.TryParse(s, out int result))
            money += result;
        this.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }
}
