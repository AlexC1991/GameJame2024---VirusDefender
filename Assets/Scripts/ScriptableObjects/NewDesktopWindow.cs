using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "DesktopResetDataContainer", menuName = "DataContainers/DesktopResetDataContainer")]
    public class NewDesktopWindow : ScriptableObject
    {
        public bool resetDesktop;
        public bool endOfDayKillBugs;
        public bool pauseSpawning;
        public bool tickTockUntilSpawning;
    }
}
