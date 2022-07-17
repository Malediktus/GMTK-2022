using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text content;
    public Canvas canvas;
    public bool containsDialog = false;

    private Queue<string> sentences;
    private static DialogManager instance;

    public static DialogManager GetDialogManager()
    {
        return instance;
    }

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        containsDialog = true;
        nameText.text = dialog.name;
        canvas.enabled = true;

        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DiplayNextSentence();
    }

    public void DiplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        content.text = sentence;
    }

    public void EndDialog()
    {
        canvas.enabled = false;
        containsDialog = false;
    }
}
