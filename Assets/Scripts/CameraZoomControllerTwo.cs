using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraZoomControllerTwo : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;
    public bool movingOn;
    private int zoomLevel;
    [SerializeField]
    private RawImage map;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;


    void Awake()
    {
        zoomLevel = 1;
        mapMinX = map.transform.position.x - map.GetComponent<RectTransform>().sizeDelta.x / 2f;
        mapMaxX = map.transform.position.x + map.GetComponent<RectTransform>().sizeDelta.x / 2f;

        mapMinY = map.transform.position.y - map.GetComponent<RectTransform>().sizeDelta.y / 2f;
        mapMaxY = map.transform.position.y + map.GetComponent<RectTransform>().sizeDelta.y / 2f;
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

            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(1))
            {
                //Debug.Log("origin " + dragOrigin + " newPosition " + cam.ScreenToWorldPoint(Input.mousePosition) + " difference " + difference);
                cam.transform.position = ClampCamera(cam.transform.position + difference);

            }
        }

    }

    public void SetCameraZoom()
    {
        int previousZoomLevel;
        previousZoomLevel = zoomLevel;
        float ScrollData;
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollData > 0 && zoomLevel < 3)
            zoomLevel++;
        if (ScrollData < 0 && zoomLevel > 1)
            zoomLevel--;

        switch (zoomLevel)
        {
            case 1:
                if (zoomLevel != previousZoomLevel)
                    StartCoroutine(ScalingZoom(540, ScrollData));
                break;
            case 2:

                if (zoomLevel != previousZoomLevel)
                    StartCoroutine(ScalingZoom(276, ScrollData));
                break;
            case 3:
                if (zoomLevel != previousZoomLevel)
                    StartCoroutine(ScalingZoom(126, ScrollData));
                break;
        }

    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;
        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);
        //Debug.Log("Valores útiles = " + newX + " " + newY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    IEnumerator ScalingZoom(int zoom, float scrollData)
    {
        float previousZoom = cam.orthographicSize;
        for (int i = 1; i < 6; i++)
        {
            cam.orthographicSize = previousZoom + (((float)zoom - previousZoom) * i) / 5f;
            //cam.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
            if (scrollData > 0 && zoomLevel == 2)
                cam.transform.position = Input.mousePosition + new Vector3(1920, 0, -10);
            if (scrollData > 0 && zoomLevel == 3 && i == 1)
                cam.transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, -10);
            cam.transform.position = ClampCamera(cam.transform.position);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
