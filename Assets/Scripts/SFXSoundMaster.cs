using UnityEngine;
namespace Batty251
{
    
    public class SFXSoundMaster : MonoBehaviour
    {
         [SerializeField] private MusicScriptableObject clickSound;
         [SerializeField] private SettingsMenuContainer musicSound;
         private int indexSound;
        

         public void PlayClickSound()
         {
             indexSound = 1;
             clickSound.sfxSoundFiles[indexSound].volume = musicSound.sfxVolume;
             clickSound.sfxSoundFiles[indexSound].PlayAudio();
         }

         public void PlayTerminalSound()
         {
             indexSound = 2;
             clickSound.sfxSoundFiles[indexSound].volume = musicSound.sfxVolume;
             clickSound.sfxSoundFiles[indexSound].PlayAudio();
         }
    }
}
