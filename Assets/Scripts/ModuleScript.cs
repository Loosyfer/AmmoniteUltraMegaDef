using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Module", menuName = "Module")]
public class ModuleScript : ScriptableObject
{

    public string moduleName;
    public string details;
    public ModuleType type;
    public RawImage moduleImage;
}
