using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalButton : MonoBehaviour
{

    public bool pushed;

    void Awake()
    {
        pushed = false;
    }

    public void push()
    {
        if (pushed)
        {
            pushed = false;
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            pushed = true;
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
