using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Player
{
    public class Interactable : MonoBehaviour
    {
        #region Singleton

        public static Interactable instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
        [SerializeField] private bool interactable;

        [Header("UI Components")] [SerializeField]
        private TextMeshProUGUI interactionText;

        [Header("2d Active scene")] [SerializeField]
        private string sceneName;

        private void Update()
        {
            if(interactable) {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Load to the 2d scene;
                    SceneManager.LoadScene(sceneName);
                }
            }
        }

        private void OnInteraction()
        {
            if (interactable)
            {
                interactionText.text = "Press E to interact";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnInteraction();
            }
        }
    }     
}
