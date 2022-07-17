using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButton : MonoBehaviour
{

    public void onClick()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/UI_Click", gameObject);
    }

    public void onHover()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/UI_Hover", gameObject);
    }
}
