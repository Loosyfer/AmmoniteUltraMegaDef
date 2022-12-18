using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Icons", menuName = "My Game/Icons")]
public class IconsInfo : ScriptableObject
{
    public Sprite[] icons = new Sprite[20];
}
