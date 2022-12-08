using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMallaRect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().position = new Vector3(960, 540, 0);
    }
}
