using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSwitcher : MonoBehaviour
{

    public NodesMapVariables mapas;
    private int index = 0;

    public void Switch()
    {
        if (index != 4)
        {
            index++;
            this.transform.GetChild(0).GetComponent<RawImage>().texture = mapas.maps[index];
        }
        else
        {
            index = 0;
            this.transform.GetChild(0).GetComponent<RawImage>().texture = mapas.maps[index];
        }
    }
}
