using UnityEngine;

namespace _Scripts.Mons
{
    [CreateAssetMenu(fileName = "New Global Dictionary", menuName = "Creatures/Global Dictionary", order = 1)]
    public class GlobalDictionary : ScriptableObject
    {
        public MonTemplate[] mons;
    }
}