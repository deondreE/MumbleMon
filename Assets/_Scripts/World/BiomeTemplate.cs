using UnityEngine;
using _Scripts.Mons;

namespace _Scripts.World
{
    [CreateAssetMenu(fileName = "New Biome", menuName = "Creatures/Biome", order = 0)]
    public class BiomeTemplate : ScriptableObject
    {
        public SpawnArea areaType;
        public Vector3 areaSize;
        public string areaName;
        [TextArea(1, 50)] public string areaDescription;
        public MonTemplate[] spawnableMons;
    }
}