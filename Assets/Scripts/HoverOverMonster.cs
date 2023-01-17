using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverMonster : MonoBehaviour
{
    public GameObject showInfoButton;

    private void OnMouseOver()
    {
        if (showInfoButton.transform.GetComponent<ShowInfoButton>().showInfo)
        {
            this.transform.GetComponent<MonsterHUD>().instructionsPanel.text = this.transform.GetComponent<MonsterHUD>().instructions;
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
    }
}
