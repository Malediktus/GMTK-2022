using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private FMOD.Studio.EventInstance MainTrack;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        MainTrack = FMODUnity.RuntimeManager.CreateInstance("event:/Music/MainTrack");

    }



    public void PlayMainTrack()
    {
        MainTrack.start();
    }
    public void StopMainTrack()
    {
        MainTrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
