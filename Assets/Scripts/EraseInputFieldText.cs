using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EraseInputFieldText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField clearIt;
    
    public void Erase()
    {
        clearIt.text = "";
    }
}
