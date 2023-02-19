using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeSlider : MonoBehaviour
{
    public GameObject monster;
    private bool active;


    private void Update()
    {
        if ((monster.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length > monster.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime))
        {
            if (monster.transform.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "Monster_Scope")
            {
                if (!active)
                {
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    this.transform.GetChild(1).gameObject.SetActive(true);
                    this.transform.GetChild(2).gameObject.SetActive(true);
                }
                this.transform.GetComponent<Slider>().value = monster.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
                active = true;
            }
            else
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                active = false;
            }
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            active = false;
        }

    }
}
