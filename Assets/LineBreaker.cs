using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineBreaker : MonoBehaviour
{

    string apoyo;

    public void LineBreak()
    {
        apoyo = this.GetComponent<TMP_InputField>().text;
        this.GetComponent<TMP_InputField>().text = apoyo + "\n";
    }

}
