using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;


public class SceneSwitcher : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject camera2;
    public Camera camera3;
    public GameObject malla;
    public GameObject canvas2;
    public GameObject healthChanger;
    public GameObject performanceChanger;
    public GameObject rngObject;
    public GameObject BG;
    public GameObject imagen;
    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
    private bool mapOn = false;
    public GameObject showInfoButton;
    public GameObject modulesFolder;
    public GameObject membersFolder;
    public BattleSystem battleSystem;
    public GameObject desactivar1;
    public GameObject desactivar2;
    public GameObject desactivar3;
    public GameObject desactivar4;
    public ItemSpawner itemSpawner;

    public void NodeMap()
    {
        foreach (GameObject module in battleSystem.modules)
        {
            module.GetComponent<Image>().enabled = false;
        }
        foreach (GameObject member in battleSystem.members)
        {
            member.GetComponent<Image>().enabled = false;
        }
        foreach (GameObject objeto in itemSpawner.objectList)
        {
            objeto.GetComponent<Image>().enabled = false;
        }
        mapOn = true;
        malla.transform.GetComponent<Canvas>().enabled = false;
        BG.SetActive(false);
        imagen.SetActive(false);
        mainCamera.SetActive(false);
        camera2.SetActive(true);
        canvas2.SetActive(true);
        desactivar1.SetActive(false);
        desactivar2.SetActive(false);
        desactivar3.SetActive(false);
        desactivar4.SetActive(false);
        
        //modulesFolder.SetActive(false);
        //membersFolder.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.transform.GetComponent<BattleSystem>().ResetTurns();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            EventSystem.current.SetSelectedGameObject(healthChanger);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            EventSystem.current.SetSelectedGameObject(performanceChanger);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rngObject.GetComponent<RNGenerator>().GenerateNumber();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            showInfoButton.GetComponent<ShowInfoButton>().switchShowInfo();
        }
    }

    public void MainGame()
    {
        foreach (GameObject module in battleSystem.modules)
            module.GetComponent<Image>().enabled = true;
        foreach (GameObject member in battleSystem.members)
            member.GetComponent<Image>().enabled = true;
        malla.transform.GetComponent<Canvas>().enabled = true;
        BG.SetActive(true);
        imagen.SetActive(true);
        mapOn = false;
        camera2.SetActive(false);
        desactivar1.SetActive(true);
        desactivar2.SetActive(true);
        desactivar3.SetActive(true);
        desactivar4.SetActive(true);
        foreach (GameObject objeto in itemSpawner.objectList)
        {
            objeto.GetComponent<Image>().enabled = true;
        }

        //canvas2.SetActive(false);
        //mainCamera.SetActive(true);
        //modulesFolder.SetActive(true);
        //membersFolder.SetActive(true);
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
        yield return new WaitForSeconds(0f);
        canvas2.SetActive(false);
        mainCamera.SetActive(true);
    }

}
