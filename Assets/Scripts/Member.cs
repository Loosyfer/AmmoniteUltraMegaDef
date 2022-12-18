using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProfessionType { Architect, Psychologist, Biologist, Developer, Engineer, Cadet, Doctor, Recruiter, Businessman, Scientist, Explorer, GeneralOficcer };

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

    public string secTrait;

    public string secTraitDescription;
}
