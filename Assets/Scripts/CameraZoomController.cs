using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoomController : MonoBehaviour
{

    private Camera cam;
    private float targetZoom;
    [SerializeField] private float zoomfactor = 200f;
    [SerializeField] private float zoomLerpSpeed = 100;
    private Vector3 dragOrigin;
    public bool movingOn;
    private MovingObject mO;
    private Canvas canvas;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public GameObject malla;
    private int zoomLevel;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
        zoomLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (movingOn == false)
        {
            if (Input.GetMouseButtonDown(1))
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(1))
            {
                //if (canvas.transform.position - 960
                //Vector3 screenPos = cam.WorldToScreenPoint(canvas.transform.position);
                //Debug.Log(screenPos.x);
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                cam.transform.position += difference;

            }
        }

    }

    public void SetCameraZoom()
    {

        float ScrollData;
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollData > 0 && zoomLevel < 3)
            zoomLevel++;
        if (ScrollData < 0 && zoomLevel > 1)
            zoomLevel--;

        Debug.Log("Zoom level is " + zoomLevel);

        switch (zoomLevel)
        {
            case 1:
                cam.orthographicSize = 528.3f;
                break;
            case 2:
                cam.orthographicSize = 276f;
                break;
            case 3:
                cam.orthographicSize = 126f;
                break;
        }

    }
}
