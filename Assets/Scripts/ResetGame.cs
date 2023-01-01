using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public GameObject surePanel;
    public FMOD.Studio.EventInstance instance;
    public GameObject stopMusic;

    public void DisplaySurePanel()
    {
        surePanel.SetActive(true);
    }

    public void HideSurePanel()
    {
        surePanel.SetActive(false);
    }


    public void ResetTheGame()
    {
        instance = stopMusic.transform.GetChild(0).GetComponent<PlaySong1>().instance;
        if (IsPlaying(instance))
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance.release();
        surePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    bool IsPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
}
