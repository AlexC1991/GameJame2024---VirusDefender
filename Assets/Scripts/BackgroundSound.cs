using System;
using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private MusicScriptableObject backGroundSound;
        [SerializeField] private SettingsMenuContainer musicSound;
        private int musicIndex;
        private float clipLenth;

        private void Start()
        {
            StartCoroutine(NewMusicToPlay());
            backGroundSound.backGroundMusic[musicIndex].volume = musicSound.musicVolume;
        }

        IEnumerator NewMusicToPlay()
        {
            if (backGroundSound != null && backGroundSound.backGroundMusic != null &&
                musicIndex < backGroundSound.backGroundMusic.Length)
            {
                backGroundSound.backGroundMusic[musicIndex].PlayAudio();
                clipLenth = backGroundSound.backGroundMusic[musicIndex].audioSource.clip.length;
                yield return null;
            }
            else
            {
                Debug.LogError("Null reference detected while starting new music.");
            }
           
        }

        private void Update()
        {
            if (backGroundSound != null && backGroundSound.backGroundMusic != null &&
                musicIndex < backGroundSound.backGroundMusic.Length)
            {
                backGroundSound.backGroundMusic[musicIndex].volume = musicSound.musicVolume;
                backGroundSound.backGroundMusic[musicIndex].volume = musicSound.masterVolume;
            }
            
            
            if (backGroundSound.backGroundMusic[musicIndex].audioSource != null && !backGroundSound.backGroundMusic[musicIndex].audioSource.isPlaying)
            {
                StartCoroutine(ChangeSong());
                StartCoroutine(NewMusicToPlay());
            }
            else if (backGroundSound.backGroundMusic[musicIndex].audioSource.isPlaying)
            {
                backGroundSound.backGroundMusic[musicIndex].UpdateVolume();
            }
            else
            {
                Debug.LogError("Null reference detected during update.");
            }
        }

        IEnumerator ChangeSong()
        {
            musicIndex += 1;

            if (musicIndex >= backGroundSound.backGroundMusic.Length)
            {
                musicIndex = 0;
            }
            
            yield return null;
        }
        
    }
}
