using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Player
{
    public class Interaction : MonoBehaviour
    {
        public static Interaction instance;

        void Awake()
        {
            instance = this;
        }

        public bool InteractButton()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                return true;

            return false;
        }

        public bool InventoryToggle()
        {
            if (Input.GetKeyDown(KeyCode.I))
                return true;

            return false;
        }
    }
}
