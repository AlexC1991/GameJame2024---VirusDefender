using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "MusicAndSoundContainer", menuName = "DataContainers/MusicAndSoundContainer")]
    public class MusicScriptableObject : ScriptableObject
    {
        public ScriptableAudioFile[] backGroundMusic;
        public ScriptableAudioFile[] sfxSoundFiles;
    }
}
