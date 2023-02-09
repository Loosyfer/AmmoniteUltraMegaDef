using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { ORGANIC, OFFENSIVE, DEFENSIVE, SCIENTIFIC, NORMAL, LEGENDARY }
public enum ModuleRequirements { CLUSTERBOOST2, POWERPAIRUP, POWERPAIRDOWN, POWERPAIRLEFT, POWERPAIRRIGHT, ISOLATED, GROUPPERFORMER, PERIPHERIALPUP, PERIPHERIALPDOWN,  HORIZONTALX4, VERTICALX3, DIFFICULT, HARDLABOUR}

public class Module : MonoBehaviour
{
    public string unitName;

    public ModuleType type;

    public string details;

    public string req;

    public int price;

    public string typeDetails;

}
