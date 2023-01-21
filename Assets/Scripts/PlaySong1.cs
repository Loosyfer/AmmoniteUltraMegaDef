using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong1 : MonoBehaviour
{
    public FMOD.Studio.EventInstance instance;

    [SerializeField]
    [Range(0, 1)]
    private int song;

    void Start()
    {
        song = 0;
        //instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Demo");
        //instance.start();
    }


    public void PlaySong()
    {
        if (!IsPlaying(instance))
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Demo");
            song = 1;
        }
        
        if (song == 0)
            song = 1;
        else
            song = 0;
        if (!IsPlaying(instance))
            instance.start();
        instance.setParameterByName("Transition", song);
    }

    bool IsPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
}