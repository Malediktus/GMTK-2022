using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSpawnPlayer : MonoBehaviour
{
    public string EventPath;
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(EventPath, gameObject);
    }

}
