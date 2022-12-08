using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
        [SerializeField] CinemachineVirtualCamera camera;
        CinemachineComponentBase componentBase;
        float cameraDistance;
        private int zoomLevel;
        

    void Start()
    {
        zoomLevel = 1;
    }
    // Update is called once per frame
    void Update()
    {
        

    }

    public void Scroll()
    {
        if (componentBase == null)
            componentBase = camera.GetCinemachineComponent(CinemachineCore.Stage.Body);

        Debug.Log("Esto triggerea");

        float ScrollData;
        ScrollData = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollData > 0 && zoomLevel < 3)
            zoomLevel++;
        if (ScrollData < 0 && zoomLevel > 1)
            zoomLevel--;
        if (componentBase is CinemachineFramingTransposer)
        {
            switch (zoomLevel)
            {
                case 1:
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = 500;
                    break;
                case 2:
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = 300;
                    break;
                case 3:
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance = 100;
                    break;
            }
        }
    }
}
