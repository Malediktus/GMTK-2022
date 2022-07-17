using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public DialogTrigger story;
    bool display = true;

    void Update()
    {
        if (display)
        {
            story.TriggerDialog();
        }

        if(DialogManager.GetDialogManager().containsDialog == false)
        {
            Debug.Log("works");
        }
    }
}
