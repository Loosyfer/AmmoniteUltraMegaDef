using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{

    private Camera cam;
    private float targetZoom;
    [SerializeField] private float zoomfactor = 100f;
    [SerializeField] private float zoomLerpSpeed = 100;
    private Vector3 dragOrigin;
    public bool movingOn;
    private MovingObject mO;
    private Canvas canvas;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public GameObject malla;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MovingOn es " + movingOn);
        PanCamera();
        float ScrollData;
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= ScrollData * zoomfactor;
        //targetZoom = Mathf.Clamp()
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
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
}
