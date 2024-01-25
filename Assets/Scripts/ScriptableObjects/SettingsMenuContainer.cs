using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "SettingsContainerMenu", menuName = "DataContainers/SettingsContainerMenu")]
    public class SettingsMenuContainer : ScriptableObject
    {
        public int amountOfClicks;
        public bool infiteSpawning;
        public bool randomizedBackground;
        public bool spawnBugsFaster;
        public float musicVolume;
        public float sfxVolume;
        public float masterVolume;
        public int backgroundSelected;
    }
}
