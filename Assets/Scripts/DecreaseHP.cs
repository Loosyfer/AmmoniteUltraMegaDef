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
        enemyHP.value += inputValue;
        this.transform.parent.GetChild(0).GetChild(3).GetComponent<Text>().text = this.transform.parent.GetChild(0).GetComponent<Slider>().value.ToString() + " HP / 3000 HP";
    }
}
