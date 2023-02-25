using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingButtonOn : MonoBehaviour
{

    public GameObject testing;

    public void ButtonOn()
    {
        if (testing.activeSelf)
            testing.SetActive(false);
        else
            testing.SetActive(true);
    }

}
