using UnityEngine;

namespace _Scripts.Mons
{
    [CreateAssetMenu(fileName = "New Move", menuName = "Dev/MonMove", order = 0)]
    public class MoveTemplate : ScriptableObject
    {
        public string moveName;
        [TextArea(0, 50)] public string moveDescription;
        public Modifiers modifiers;
    }

    [SerializeField]
    public enum EffectType
    {
         None,
         Broken,
         Weak,
         Poison
    }

    [System.Serializable]
    public class Modifiers
    {
        public EffectType effectType;
        public BaseType moveType;
        public float defense;
        public float speed;
        public float health;
        public float damage;
        public int uses;
    }
}