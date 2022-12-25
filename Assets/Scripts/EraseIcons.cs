using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseIcons : MonoBehaviour
{
    public GameObject iconsFolder;

    public void Erase()
    {

        foreach (GameObject icon in iconsFolder.GetComponent<IconsFolder>().icons)
        {
            Destroy(icon);
        }
        iconsFolder.GetComponent<IconsFolder>().icons.Clear();
    }
}
