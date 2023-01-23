using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeeEventDescription : MonoBehaviour
{
    public GameObject eventDesc;
    private bool ispressed;

    private void Update()
    {
        if (ispressed)
            eventDesc.gameObject.SetActive(true);
        else
            eventDesc.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        ispressed = true;
    }

    private void OnMouseUp()
    {
        ispressed = false;
    }
}
