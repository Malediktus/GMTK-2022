using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/TEST", gameObject);
    }
}
