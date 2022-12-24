using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faces : MonoBehaviour
{

    MemberHUD member;

    public void Asleep()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(12).gameObject.activeSelf)
                {
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                }
                    
                else
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(12).gameObject.SetActive(true);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Frozen()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(13).gameObject.activeSelf)
                {
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Lunatic()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(14).gameObject.activeSelf)
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(14).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Stunned()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(17).gameObject.activeSelf)
                {
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Poisoned()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(15).gameObject.activeSelf)
                {
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Sick()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(16).gameObject.activeSelf)
                {
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

    public void Sleepy()
    {
        if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember != null)
        {
            if (transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.tag == "Member")
            {
                member = transform.parent.GetComponent<GameObjectHolder>().activeModuleorMember.GetComponent<MemberHUD>();
                if (member.transform.GetChild(18).gameObject.activeSelf)
                {
                    member.transform.GetChild(18).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
                }

                else
                {
                    member.transform.GetChild(14).gameObject.SetActive(false);
                    member.transform.GetChild(15).gameObject.SetActive(false);
                    member.transform.GetChild(16).gameObject.SetActive(false);
                    member.transform.GetChild(17).gameObject.SetActive(false);
                    member.transform.GetChild(12).gameObject.SetActive(false);
                    member.transform.GetChild(13).gameObject.SetActive(false);
                    member.transform.GetChild(18).gameObject.SetActive(true);
                    gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).GetChild(1).gameObject.SetActive(true);
                }
            }
        }

    }

}
