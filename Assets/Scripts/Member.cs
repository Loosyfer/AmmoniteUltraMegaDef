using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProfessionType { ARCHITECT, PSYCHOLOGIST, BIOLOGIST, DEVELOPER, ENGINEER, CADET, DOCTOR, RECRUITER, BUSINESSMAN, SCIENTIST, EXPLORER, GENERALOFFICER };

public class Member : MonoBehaviour
{
    public string unitName;

    public ProfessionType unitProfession;

    public string professionDetails;

    public string traitDetails;

    public string trait;

    public int totalPrice;

    public int profPrice;

    public int traitPrice;

    public int performance;
}
