using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RNGenerator : MonoBehaviour
{

    private float number;
    private string numberGenerated;
    private string apoyo;

    public void GenerateNumber()
    {
        number = Random.Range(0f, 100f);
        number = Mathf.Round(number);
        apoyo = number.ToString();
        numberGenerated = apoyo + " %";
        transform.GetComponent<TextMeshProUGUI>().text = numberGenerated;
        this.transform.parent.GetChild(0).transform.GetComponent<Animator>().Play("RNGPress");
    }



}
