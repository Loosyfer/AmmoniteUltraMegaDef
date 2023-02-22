using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWarnings : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void ActivesWarning()
    {
        switch (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.tag)
        {
            case "Module":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny2_module"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny2_module");
                break;
            case "Member":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny2_member"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny2_member");
                break;
        }
        
    }

    public void FourTurns()
    {
        switch (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.tag)
        {
            case "Module":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny_module"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny_module");
                break;
            case "Member":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny_member"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny_member");
                break;
        }
    }

    public void TwoTurns()
    {
        switch (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.tag)
        {
            case "Module":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny3_module"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny3_module");
                break;
            case "Member":
                if (this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shiny3_member"))
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Nothing");
                else
                    this.transform.GetComponentInParent<GameObjectHolder>().activeModuleorMember.GetComponent<Animator>().Play("Shiny3_member");
                break;
        }
    }


}
