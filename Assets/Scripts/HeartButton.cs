using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartButton : MonoBehaviour
{

    private bool active;
    private Image image;


    void Start()
    {
        active = true;
    }

    public void ChangeColor()
    {
        image = this.GetComponent<Image>();
        if (active)
        {
            image.color = new Color32(219, 57, 57, 255);
            active = false;
        }
        else
        {
            image.color = new Color(1,1,1,1);
            active = true;
        }
    }
}
