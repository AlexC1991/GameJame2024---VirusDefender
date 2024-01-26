using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "StatusEffectsOnBug", menuName = "DataContainers/StatusEffectsOnBug")]
    public class StatusEffects : ScriptableObject
    {
        public Color originalTileColorEffect;
        public Color tileSlowEffectColor = Color.cyan;
        public bool _changedTheColor;
        public float bugSpeed;
    }
}