using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverOverStacks : MonoBehaviour
{
    
    private void OnMouseOver()
    {
        this.transform.GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color32(99, 230, 241, 255);
    }

    private void OnMouseExit()
    {
        this.transform.GetChild(2).gameObject.SetActive(false);
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
    }
}
