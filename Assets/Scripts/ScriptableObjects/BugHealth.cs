using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "BugHealthStart", menuName = "DataContainers/BugHealthStart")]
    public class BugHealth : ScriptableObject
    {
        public float bugHealthMin = 30f;
        public float bugHealthMax = 80f;
        public float bossBugHealth = 110f;
        public float harderBossBugHealth = 150f;


        public float virusBugDamageMax = 40f;
        public float virusBugDamageMin = 5f;
        public float areaOfEffectDamageMax = 8f;
        public float areaOfEffectDamageMin = 2f;
    }
}
