using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterHUD : MonoBehaviour
{

    public bool selected;
    public GameObjectHolder script;
    public string instructions;
    public string name;
    public string flavour;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        if (script.activeModuleorMember != null)
        {
            if (script.activeModuleorMember.tag == "Module")
                script.activeModuleorMember.GetComponent<ModuleHUD>().selected = false;
            if (script.activeModuleorMember.tag == "Member")
                script.activeModuleorMember.GetComponent<MemberHUD>().selected = false;
            if (script.activeModuleorMember.tag == "Mega")
                script.activeModuleorMember.GetComponent<MegaHUD>().selected = false;
            if (script.activeModuleorMember.tag == "Mega2")
                script.activeModuleorMember.GetComponent<MegaVerHUD>().selected = false;
        }
        script.activeModuleorMember = EventSystem.current.currentSelectedGameObject;
        selected = true;
        this.transform.GetComponent<SpriteRenderer>().color = new Color32(120, 120, 120, 255);
    }
}
