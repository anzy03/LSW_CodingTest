using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueDisplayer : MonoBehaviour
{
    private DialougeData _dialougeData;
    private int _dialogueIndex = 0;
    private TMP_Text _text;

    public UnityEvent DialogueOverEvent;
    public UnityEvent DialogueBoxEnable;

    private void Awake()
    {
        _dialougeData = Resources.Load<DialougeData>("ScriptableData/Data/ShopDialogue");
        if (_dialougeData == null)
        {
            // Check to see if Dialogue Data is not loaded Properly.
            Debug.LogWarning("Dialogue Data is Null");
        }

        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        DialogueBoxEnable.Invoke();
        _dialogueIndex = 0;
        DisplayDialogue();
    }

    /// <summary>
    /// Called to Update Dialogue Index and call DisplayDialogue().
    /// </summary>
    public void NextDialogue()
    {
        _dialogueIndex++;
        DisplayDialogue();
    }

    /// <summary>
    /// Displays Dialogue Based on DialogueIndex when called.
    /// </summary>
    private void DisplayDialogue()
    {
        if (_dialogueIndex < _dialougeData.Dialogues.Length - 1)
        {
            _text.text = _dialougeData.Dialogues[_dialogueIndex];
        }
        else
        {
            _text.text = _dialougeData.Dialogues[_dialogueIndex];
            DialogueOverEvent.Invoke();
        }
    }
}