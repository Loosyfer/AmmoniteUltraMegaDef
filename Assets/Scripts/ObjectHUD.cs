using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectHUD : MonoBehaviour
{

    public string name;
    public string description;
    public GameObject descriptionPanel;
    public GameObject namePanel;

    private void Update()
    {
        descriptionPanel.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = description;
        namePanel.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = name;
    }

}
