using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecicleBin : MonoBehaviour, IDropHandler
{

    public Camera camera;
    public BattleSystem script;
    

    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.tag == "Module")
                script.modules.Remove(eventData.pointerDrag);
            if (eventData.pointerDrag.tag == "Member")
                script.members.Remove(eventData.pointerDrag);
            Destroy(eventData.pointerDrag);
            SceneManager.GetActiveScene().GetRootGameObjects()[0].GetComponent<CameraZoomController>().movingOn = false;
        }
    }

}
