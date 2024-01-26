using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Batty251
{
    public class SettingsMenuUsageScript : MonoBehaviour
    {
        [SerializeField] private SettingsMenuContainer settingsToKeep;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider masterSlider;
        [SerializeField] private InputField textResult;
        [SerializeField] private Sprite[] imageSelectionForBackground;
        [SerializeField] private Image displayedBackground;
        [SerializeField] private GameObject wallPaperBackgroundImage;
        [SerializeField] private GameObject spawnMoreYesButton;
        [SerializeField] private GameObject spawnMoreNoButton;
        [SerializeField] private GameObject spawnFasterYesButton;
        [SerializeField] private GameObject spawnFasterNoButton;
        [SerializeField] private GameObject randomYesButton;
        [SerializeField] private GameObject randomNoButton;
        [SerializeField] private DayAndWeekTrackerContainer randomBool;
        private Color originalButtonColor;
        private Color targetButtonColor = Color.green;
        private int backgroundSelection;
        private bool spawnFaster;
        private bool backGroundRandomized;
        private bool spawnInfinityBugs;
        private float currentMusicSliderValue;
        private float maxMusicSliderValue = 1;
        private float currentSFXSliderValue;
        private float maxSFXSliderValue = 1;
        private float currentVolumeTotal;
        private float maxMasterVolumeTotal = 1;
        private int wallPaperNumber;
        
        private void Start()
        {
            originalButtonColor = spawnMoreYesButton.GetComponent<Image>().color;
            musicSlider.value = settingsToKeep.musicVolume;
            sfxSlider.value = settingsToKeep.sfxVolume;
            masterSlider.value = settingsToKeep.masterVolume;
            textResult.text = settingsToKeep.amountOfClicks.ToString();
            backgroundSelection = settingsToKeep.backgroundSelected;
            displayedBackground.sprite = imageSelectionForBackground[backgroundSelection];
            spawnFaster = settingsToKeep.spawnBugsFaster;
            backGroundRandomized = settingsToKeep.randomizedBackground;
            spawnInfinityBugs = settingsToKeep.infiteSpawning;
            musicSlider.minValue = 0;
            musicSlider.maxValue = maxMasterVolumeTotal;
            sfxSlider.minValue = 0;
            sfxSlider.maxValue = maxSFXSliderValue;
            masterSlider.minValue = 0;
            masterSlider.maxValue = maxMasterVolumeTotal;
            currentMusicSliderValue = musicSlider.value;
            currentSFXSliderValue = sfxSlider.value;
            currentVolumeTotal = masterSlider.value;
            wallPaperBackgroundImage.GetComponent<SpriteRenderer>().sprite = displayedBackground.sprite;

            if (settingsToKeep.spawnBugsFaster)
            {
                YesSpawnFaster();
            }
            else
            {
                NotSpawnFaster();
            }

            if (settingsToKeep.infiteSpawning)
            {
                YesSpawnMore();
            }
            else
            {
                NotSpawnMore();
            }

            if (settingsToKeep.randomizedBackground)
            {
                YesRandomBackGround();
            }
            else
            {
                NoRandomBackGround();
            }
        }
        
        private void Update()
        {
            musicSlider.value = MusicSliderSettings();
            sfxSlider.value = SFXSliderSettings();
            masterSlider.value = MasterVolumeSettings();
            settingsToKeep.musicVolume = musicSlider.value;
            settingsToKeep.sfxVolume = sfxSlider.value;
            settingsToKeep.masterVolume = masterSlider.value;
        }
        
        private float MusicSliderSettings()
        {
            return musicSlider.value / maxMusicSliderValue;
        }

        private float SFXSliderSettings()
        {
            return sfxSlider.value / maxSFXSliderValue;
        }

        private float MasterVolumeSettings()
        {
            return masterSlider.value / maxMasterVolumeTotal;
        }

        IEnumerator SaveSpawnMoreBool()
        {
            if (spawnInfinityBugs)
            {
                settingsToKeep.infiteSpawning = true;
            }
            else
            {
                settingsToKeep.infiteSpawning = false;
            }
            yield return null;
        }

        IEnumerator StartSpawningFasterBool()
        {
            if (spawnFaster)
            {
                settingsToKeep.spawnBugsFaster = true;
            }
            else
            {
                settingsToKeep.spawnBugsFaster = false;
                
            }
            yield return null;
        }

        IEnumerator BackGroundSelectionNullAndVoidCheck()
        {
            if (backGroundRandomized)
            {
                if (randomBool.changeWallpaperIfRandom)
                {
                    backgroundSelection += 1;
                    displayedBackground.sprite = imageSelectionForBackground[backgroundSelection];
                    wallPaperBackgroundImage.GetComponent<SpriteRenderer>().sprite = displayedBackground.sprite;
                    if (backgroundSelection >= 8)
                    {
                        backgroundSelection = -1;
                    }

                }
                settingsToKeep.randomizedBackground = true;
            }
            else
            {
                settingsToKeep.randomizedBackground = false;
            }
            yield return null;
        }

        IEnumerator MinusTheSelectionBackGround()
        {
            backgroundSelection -= 1;

            if (backgroundSelection == 0)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 0;
                displayedBackground.sprite = imageSelectionForBackground[0];
            }
            else if (backgroundSelection == 1)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 1;
                displayedBackground.sprite = imageSelectionForBackground[1];
            }
            else if (backgroundSelection == 2)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 2;
                displayedBackground.sprite = imageSelectionForBackground[2];
            }
            else if (backgroundSelection == 3)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 3;
                displayedBackground.sprite = imageSelectionForBackground[3];
            }
            else if (backgroundSelection == 4)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 4;
                displayedBackground.sprite = imageSelectionForBackground[4];
            }
            else if (backgroundSelection == 5)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 5;
                displayedBackground.sprite = imageSelectionForBackground[5];
            }
            else if (backgroundSelection == 6)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 6;
                displayedBackground.sprite = imageSelectionForBackground[6];
            }
            else if (backgroundSelection == 7)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 7;
                displayedBackground.sprite = imageSelectionForBackground[7];
            }
            else if (backgroundSelection == 8)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 8;
                displayedBackground.sprite = imageSelectionForBackground[8];
            }

            if (backgroundSelection  <= 0)
            {
                backgroundSelection = 9;
            }
            
            wallPaperBackgroundImage.GetComponent<SpriteRenderer>().sprite = displayedBackground.sprite;
            
            yield return null;
        }
        
        IEnumerator PlusTheSelectionBackGround()
        {
            backgroundSelection += 1;

            if (backgroundSelection == 0)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 0;
                displayedBackground.sprite = imageSelectionForBackground[0];
            }
            else if (backgroundSelection == 1)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 1;
                displayedBackground.sprite = imageSelectionForBackground[1];
            }
            else if (backgroundSelection == 2)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 2;
                displayedBackground.sprite = imageSelectionForBackground[2];
            }
            else if (backgroundSelection == 3)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 3;
                displayedBackground.sprite = imageSelectionForBackground[3];
            }
            else if (backgroundSelection == 4)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 4;
                displayedBackground.sprite = imageSelectionForBackground[4];
            }
            else if (backgroundSelection == 5)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 5;
                displayedBackground.sprite = imageSelectionForBackground[5];
            }
            else if (backgroundSelection == 6)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 6;
                displayedBackground.sprite = imageSelectionForBackground[6];
            }
            else if (backgroundSelection == 7)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 7;
                displayedBackground.sprite = imageSelectionForBackground[7];
            }
            else if (backgroundSelection == 8)
            {
                settingsToKeep.backgroundSelected = backgroundSelection = 8;
                displayedBackground.sprite = imageSelectionForBackground[8];
            }

            if (backgroundSelection >= 8)
            {
                backgroundSelection = -1;
            }
            
            wallPaperBackgroundImage.GetComponent<SpriteRenderer>().sprite = displayedBackground.sprite;
            
            yield return null;
        }

        public void YesSpawnMore()
        {
            spawnInfinityBugs = true;
            spawnMoreYesButton.GetComponent<Image>().color = targetButtonColor;
            spawnMoreNoButton.GetComponent<Image>().color = originalButtonColor;
            StartCoroutine(SaveSpawnMoreBool());
        }

        public void NotSpawnMore()
        {
            spawnInfinityBugs = false;
            spawnMoreYesButton.GetComponent<Image>().color = originalButtonColor;
            spawnMoreNoButton.GetComponent<Image>().color = targetButtonColor;
            StartCoroutine(SaveSpawnMoreBool());
        }

        public void YesSpawnFaster()
        {
            spawnFaster = true;
            spawnFasterYesButton.GetComponent<Image>().color = targetButtonColor;
            spawnFasterNoButton.GetComponent<Image>().color = originalButtonColor;
            StartCoroutine(StartSpawningFasterBool());
        }

        public void NotSpawnFaster()
        {
            spawnFaster = false;
            spawnFasterYesButton.GetComponent<Image>().color = originalButtonColor;
            spawnFasterNoButton.GetComponent<Image>().color = targetButtonColor;
            StartCoroutine(StartSpawningFasterBool());
        }

        public void YesRandomBackGround()
        {
            backGroundRandomized = true;
            randomYesButton.GetComponent<Image>().color = targetButtonColor;
            randomNoButton.GetComponent<Image>().color = originalButtonColor;
            StartCoroutine(BackGroundSelectionNullAndVoidCheck());
        }
        
        public void NoRandomBackGround()
        {
            backGroundRandomized = false;
            randomYesButton.GetComponent<Image>().color = originalButtonColor;
            randomNoButton.GetComponent<Image>().color = targetButtonColor;
            StartCoroutine(BackGroundSelectionNullAndVoidCheck());
        }

        public void ChangeBackgroundLess()
        {
            if (!backGroundRandomized)
            {
                StartCoroutine(MinusTheSelectionBackGround());
            }
            
        }

        public void ChangeBackgroundMore()
        {
            if (!backGroundRandomized)
            {
                StartCoroutine(PlusTheSelectionBackGround());
            }
            
        }

        public void OnTextResultValueChanged(string newValue)
        {
            // Parse the string to an integer
            if (int.TryParse(newValue, out int result))
            {
                // If successful, update the settingsToKeep.amountOfClicks
                settingsToKeep.amountOfClicks = result;
            }
            else
            {
                // If parsing fails, you may want to handle it accordingly
                Debug.LogWarning("Invalid input for amountOfClicks");
            }
        }
        public void SaveTextForClickCount()
        {
            // Save the amountOfClicks to the settingsToKeep and update the UI
            settingsToKeep.amountOfClicks = int.Parse(textResult.text);
            textResult.text = settingsToKeep.amountOfClicks.ToString();
        }
    }
}
