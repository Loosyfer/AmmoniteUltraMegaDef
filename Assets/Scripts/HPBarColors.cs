using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarColors : MonoBehaviour
{

    public Image imagen;
    public bool swapColours = false;

    public void ChangeColour()
    {
        switch (swapColours)
        {
            case false:
                {
                    imagen.color = new Color32(129, 130, 129, 255);
                    swapColours = true;
                    break;
                }
            case true:
                {
                    imagen.color = new Color32(15, 255, 0, 255);
                    swapColours = false;
                    break;
                }
        }
        
    }

}
