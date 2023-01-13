using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverStacks : MonoBehaviour
{
    
    private void OnMouseOver()
    {
        this.transform.GetChild(2).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        this.transform.GetChild(2).gameObject.SetActive(false);
    }
}
