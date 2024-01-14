using UnityEngine;

namespace Batty251
{
    [CreateAssetMenu(fileName = "DataContainer", menuName = "ScriptableObjects/BarrierDataContainer", order = 1)]
    public class BarrierDataContiner : ScriptableObject
    {
        public bool hitWall;
    }
}
