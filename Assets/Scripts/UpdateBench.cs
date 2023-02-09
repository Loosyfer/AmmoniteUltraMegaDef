using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBench : MonoBehaviour
{

    private int bench;

    private void Awake()
    {
        bench = 1;
    }

    public void UpdateB(string s)
    {
        bench = int.Parse(s) + bench;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = bench.ToString();
    }
}
