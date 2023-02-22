using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonsterAnimations : MonoBehaviour
{

    private bool burn = false;
    private bool freeze = false;
    private bool poison = false;
    private bool blind = false;
    private bool berserk = false;
    private bool sleep = false;

    public void Burn()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!burn)
        {
            animator.Play("Monster_Burn");
            burn = true;
        }
        else
        {
            animator.Play("Nothing");
            burn = false;
        }
    }

    public void Freeze()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!freeze)
        {
            animator.Play("Monster_Freeze");
            freeze = true;
        }
        else
        {
            animator.Play("Nothing");
            freeze = false;
        }
    }

    public void Poison()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!poison)
        {
            animator.Play("Monster_Poison");
            poison = true;
        }
        else
        {
            animator.Play("Nothing");
            poison = false;
        }
    }

    public void Blind()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!blind)
        {
            animator.Play("Monster_Blind");
            blind = true;
        }
        else
        {
            animator.Play("Nothing");
            blind = false;
        }
    }

    public void Berserk()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!berserk)
        {
            animator.Play("Monster_Berserk");
            berserk = true;
        }
        else
        {
            animator.Play("Nothing");
            berserk = false;
        }
    }

    public void Sleep()
    {
        Animator animator = this.transform.GetComponent<Animator>();
        if (!sleep)
        {
            animator.Play("Monster_Sleep");
            sleep = true;
        }
        else
        {
            animator.Play("Nothing");
            sleep = false;
        }
    }
}
