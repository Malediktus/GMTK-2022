using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODBanks : MonoBehaviour
{

    bool audioResumed = false;
    public void Start()
    {
        if (!audioResumed)
        {
            var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            //  Debug.Log(result);
            result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            //  Debug.Log(result);
            audioResumed = true;
        }
    }


    private void Awake()
    {
        FMODUnity.RuntimeManager.LoadBank("Main");
        FMODUnity.RuntimeManager.LoadBank("Main.strings");
    }
}
