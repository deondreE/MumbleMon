using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion
        
        
        #region Global Content
        [Header("Global Content")] 
        public float gravity = 9f;
        public float gravityMultiplier = 2f;
        public float groundedGravity = -0.5f;
        public int MAXMONCOUNT;
        public int MAXSHINYCOUNT;
        #endregion

    }
}

