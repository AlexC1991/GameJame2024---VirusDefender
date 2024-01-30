using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class VirusDefenderTwoScript : MonoBehaviour
    {
        [SerializeField] private GameObject scanningWindow;
        [SerializeField] private GameObject[] percentageIndicators;
        [SerializeField] private GameObject percentageText;
        [SerializeField] private Text percentageIndicatorText;
        [SerializeField] private GameObject bugContainer;
        [SerializeField] private WindowsOpen isItOpened;
        [SerializeField] private GameObject cooldownErrorMessage;
        [SerializeField] private SettingsMenuContainer clickChecker;
        [SerializeField] private MusicScriptableObject windowLoadingSound;
        [SerializeField] private StatusEffects slowBugsDown;
        private ParticleSystem thisObjectsParticles;
        private CoolDownProgramTwo coolingDownScript;
        private GameObject[] childObjects;
        private Transform childrenInParent;
        private int clickAmount;
        private Sprite thisSprite;

        private void Awake()
        {
            thisObjectsParticles = GetComponent<ParticleSystem>();
            thisSprite = gameObject.GetComponent<Image>().sprite;
            coolingDownScript = gameObject.GetComponent<CoolDownProgramTwo>();
            clickAmount = 0;
            
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
            scanningWindow.SetActive(false);
        }

        private void Start()
        {
            foreach (GameObject indicators in percentageIndicators)
            {
                indicators.SetActive(false);
            }
        }

        public void DoubleClickerStart()
        {
            if (!isItOpened.isAWindowOpened)
            {
                StartCoroutine(DoubleCLickCoroutine());
            }
           
        }
        
        private void OnStart()
        {
            if (!isItOpened.isAWindowOpened)
            {
                StartCoroutine(PercentageCalculateStart());
            }
        }

        IEnumerator DoubleCLickCoroutine()
        {
            clickAmount += clickChecker.amountOfClicks;
            yield break;
        }

        private void Update()
        {
            if (clickAmount >= clickChecker.amountOfClicks && GetComponent<Image>().sprite == thisSprite )
            {
                OnStart();
                clickAmount = 0;
            }

            if (GetComponent<Image>().sprite != thisSprite && clickAmount >= clickChecker.amountOfClicks)
            {
                StartCoroutine(CoolingErrorMessage());
                clickAmount = 0;
            }
        }

        IEnumerator CoolingErrorMessage()
        {
            cooldownErrorMessage.SetActive(true);
            yield return new WaitForSeconds(2);
            cooldownErrorMessage.SetActive(false);
        }

        IEnumerator PercentageCalculateStart()
        {
            isItOpened.isAWindowOpened = true;
            scanningWindow.SetActive(true);
            percentageText.SetActive(true);
            windowLoadingSound.sfxSoundFiles[3].PlayAudio();
            percentageIndicatorText.text = "1%";
            percentageIndicators[0].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "5%";
            percentageIndicators[1].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "8%";
            percentageIndicators[2].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "12%";
            percentageIndicators[3].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "20%";
            percentageIndicators[4].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "29%";
            percentageIndicators[5].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "34%";
            percentageIndicators[6].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "40%";
            percentageIndicators[7].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "52%";
            percentageIndicators[8].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "59%";
            percentageIndicators[9].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "65%";
            percentageIndicators[10].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "69%";
            percentageIndicators[11].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "74%";
            percentageIndicators[12].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "79%";
            percentageIndicators[13].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "85%";
            percentageIndicators[14].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "92%";
            percentageIndicators[15].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "96%";
            percentageIndicators[16].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "98%";
            percentageIndicators[17].SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
            percentageIndicatorText.text = "99%";
            percentageIndicators[18].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            scanningWindow.SetActive(false);
            percentageText.SetActive(false);
            isItOpened.isAWindowOpened = false;
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
            childrenInParent = bugContainer.transform;
            childObjects = GetAllChildren(childrenInParent);
            StartCoroutine(CoolingDownNowMode());
            foreach (GameObject indicators in percentageIndicators)
            {
                indicators.SetActive(false);
            }
            thisObjectsParticles.Play();
            StartCoroutine(GetThemBugs());
            yield return new WaitForSecondsRealtime(1f);
            thisObjectsParticles.Stop();
        }
        
        IEnumerator GetThemBugs()
        {
            StartCoroutine(CoolingDownNowMode());
            float originalBugMovementSpeed = slowBugsDown.bugSpeed;

            foreach (var g in childObjects)
            {
                g.GetComponent<DynamicHealthIndicator>().TakeDamage(30);
            }
            slowBugsDown.bugSpeed = originalBugMovementSpeed;
            yield return null;
        }


        IEnumerator CoolingDownNowMode()
        {
            coolingDownScript.StartCoolDown();
            yield break;
        }
        
        private GameObject[] GetAllChildren(Transform parent)
        {
            int childCount = parent.childCount;
            GameObject[] children = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                Transform child = parent.GetChild(i);
                children[i] = child.gameObject;
            }

            return children;
        }
    }
}
