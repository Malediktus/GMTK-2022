using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEventPlayer : MonoBehaviour
{
    public string EventPath;
    private void PlayEvent()
    {

        FMODUnity.RuntimeManager.PlayOneShotAttached(EventPath, gameObject);

    }

}
