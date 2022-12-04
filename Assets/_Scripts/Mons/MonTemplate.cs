using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.Mons
{
    [CreateAssetMenu(fileName = "New MumbleMon", menuName = "Creatures/MumbleMon", order = 0)]
    public class MonTemplate : ScriptableObject
    {
        public Template mon;
    }

    [System.Serializable]
    public class Template
    {
        public string name;
        [TextArea(0, 100)]
        public string description;
        [Tooltip("Mons can have up to 5 moves depending on the lvl of the Mon")]
        public MoveTemplate[] moves;
        public Stats stats;
        public GameObject prefab;
        public GameObject shinyPrefab;
    }

    // BaseType Will be similar to the Nature Style of Normal Pokemon games
    [SerializeField]
    public enum BaseType
    {
        Thoughtful,
        Fast,
        Strong,
        Smart,
        None
    }

    // SpawnArea is where the Mon can be found
    [SerializeField]
    public enum SpawnArea
    {
        Desert,
        Forest,
        None
    }

    //  The base stats for the mons
    [System.Serializable]
    public class Stats
    {
        public BaseType baseType;
        public float baseAttack;
        public float baseDefense;
        public float baseSpeed;
        public SpawnInformation spawnInfo;
    }

    // The spawn information for each specific mon
    [System.Serializable]
    public class SpawnInformation
    {
        public float baseRarity;
        public float shinyRarity;
        public int groupSize;
        public SpawnArea spawnArea;
        public Texture2D image;
    }
}