using UnityEngine;

namespace _Scripts.Interface.Dialogue
{
    [System.Serializable]
    public class Dialogue
    {
        public string name;
        
        [TextArea(0, 50)]
        public string[] sentences;
    }
}