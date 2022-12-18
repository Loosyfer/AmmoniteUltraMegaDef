using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


public class SceneSwitcher : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject camera2;
    public Camera camera3;
    public GameObject malla;
    public GameObject canvas2;
    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
    private bool mapOn = false;

    public void NodeMap()
    {
        mapOn = true;
        mainCamera.SetActive(false);
        camera2.SetActive(true);
        malla.SetActive(false);
        canvas2.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
            if (mapOn)
                MainGame();
            else
                NodeMap();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.GetComponent<BattleSystem>().TurnButtonClick();
        }
    }

    public void MainGame()
    {
        mapOn = false;
        malla.SetActive(true);
        camera2.SetActive(false);
        StartCoroutine(Screenshot(camera3));
        StartCoroutine(DeactivateCanvas());
    }

    IEnumerator Screenshot(Camera cam)
    {
        RenderTexture screenTexture = new RenderTexture(650, 1080, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(650, 1080);
        yield return frameEnd;
        renderedTexture.ReadPixels(new Rect(0, 0, 650, 1080), 0, 0);

        //byte[] byteArray = renderedTexture.EncodeToPNG();
        //AssetDatabase.DeleteAsset("Assets/CameraScreenshot.png");
        //System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
        //malla.transform.GetChild(29).GetComponent<RawImage>().texture = (Texture)AssetDatabase.LoadAssetAtPath("Assets/CameraScreenshot.png", typeof(Texture));
        malla.transform.GetChild(29).GetComponent<RawImage>().texture = renderedTexture;

        cam.targetTexture = null;
    }

    IEnumerator DeactivateCanvas()
    {
        yield return new WaitForSeconds(0.05f);
        canvas2.SetActive(false);
        mainCamera.SetActive(true);
    }

}
