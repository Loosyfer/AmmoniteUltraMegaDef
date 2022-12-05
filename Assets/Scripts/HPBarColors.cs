using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarColors : MonoBehaviour
{

    public SpriteRenderer imagen;
    public int swapColours = 1;

    public void ChangeColour()
    {
        switch (swapColours)
        {
            case 1:
                {
                    imagen.color = new Color(0.3098f, 0.3098f, 0.3098f, 1);
                    swapColours = 0;
                    break;
                }
            case 0:
                {
                    imagen.color = new Color(1, 0.9333333f, 0.3372549f, 1);
                    swapColours = 3;
                    break;
                }
            case 3:
                {
                    imagen.color = new Color(0.1137255f, 0.7960784f, 0.9764706f, 1);
                    swapColours = 2;
                    break;
                }
            case 2:
                {
                    imagen.color = new Color(0.3607843f, 0.9490196f, 0.5333334f, 1);
                    swapColours = 1;
                    break;
                }
        }
        
    }

}
