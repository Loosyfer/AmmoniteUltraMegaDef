using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { ORGANIC, OFFENSIVE, DEFENSIVE, SCIENTIFIC, NORMAL, SPECIAL }
public enum ModuleRequirements { CLUSTERBOOST1, CLUSTERBOOST2, POWERPAIRUP, POWERPAIRDOWN, POWERPAIRLEFT, POWERPAIRRIGHT, ISOLATED, PERIPHERIALPUP, PERIPHERIALPDOWN,  HORIZONTALX4, VERTICALX3}

public class Module : MonoBehaviour
{
    public string unitName;

    public ModuleType type;

    public string details;

    public ModuleRequirements req;
}
