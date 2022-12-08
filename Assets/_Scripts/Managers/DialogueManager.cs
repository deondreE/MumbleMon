using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Interface.Dialogue;
using UnityEngine;
using TMPro;

namespace _Scripts.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject dialogueBox;
        
        #region Singleton

        public static DialogueManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
        
        private Queue<string> _sentences;
        
        private void Start()
        {
            _sentences = new Queue<string>();
        }

        /// <summary>
        /// Start the dialogue Sequence, then check for the next sentence.
        /// </summary>
        /// <param name="dialogue">Scriptable Object that contains information about the dialogue to be spoken</param>
        public void StartDialogue(Dialogue dialogue)
        {
            dialogueBox.SetActive(true
            );
            _sentences.Clear();

            nameText.text = dialogue.name;

            foreach (var sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        
        /// <summary>
        /// Display the next sentence in a given sentence array. If there are none left, EndDialogue
        /// </summary>
        public void DisplayNextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeLetters(sentence));
        }

        private IEnumerator TypeLetters(string sentence)
        {
            dialogueText.text = "";

            foreach (var letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
            
        private void EndDialogue()
        {
            dialogueBox.SetActive(!dialogueBox.activeSelf);
        }
    }
}