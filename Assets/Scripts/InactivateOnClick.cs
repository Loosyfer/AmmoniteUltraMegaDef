using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactivateOnClick : MonoBehaviour
{
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
