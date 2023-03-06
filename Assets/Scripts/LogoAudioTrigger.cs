using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAudioTrigger : MonoBehaviour
{

    void Start()
    {
        Invoke("PlayLogoSound", 0.6f);
        Invoke("ChangeScene", 5);
    }

    void PlayLogoSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music/LogoFanMade");
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

}
