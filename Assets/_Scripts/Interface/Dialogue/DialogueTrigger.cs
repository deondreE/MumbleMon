using System;
using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Interface.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private Dialogue dialogue;

        private DialogueManager _dialogueManager;

        private void Awake()
        {
            _dialogueManager = DialogueManager.instance;
        }

        public void TriggerDialogue()
        {
            _dialogueManager.StartDialogue(dialogue);
        }
    }
}