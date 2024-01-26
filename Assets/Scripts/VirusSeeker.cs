using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Batty251
{
    public class VirusSeeker : MonoBehaviour
    {

        [SerializeField] private GameObject scanningWindow;
        [SerializeField] private GameObject percentageText;
        [SerializeField] private GameObject[] percentageIndicators;
        [SerializeField] private Text percentageIndicatorText;
        [SerializeField] private GameObject foundBugsResultScreen;
        [SerializeField] private Text totalBugFoundText;
        [SerializeField] private GameObject bugContainer;
        [SerializeField] private WindowsOpen isItOpened;
        [SerializeField] private GameObject cooldownErrorMessage;
        [SerializeField] private BugTotalContainer addedTotal;
        [SerializeField] private SettingsMenuContainer clickChecker;
        [SerializeField] private StatusEffects bugMovementSpeed;
        [SerializeField] private MusicScriptableObject bugDeathSound;
        private CoolDownInProgressScript coolingDownScript;
        private Transform childrenInParent;
        private GameObject[] childObjects;
        private int numChildrenToDelete;
        private Sprite thisSprite;
        private int clickAmount;

        private void Awake()
        {
            thisSprite = gameObject.GetComponent<Image>().sprite;
            coolingDownScript = gameObject.GetComponent<CoolDownInProgressScript>();
            scanningWindow.SetActive(false);
            percentageText.SetActive(false);
            foundBugsResultScreen.SetActive(false);
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
        }

        public void DoubleClickerStart()
        {
            if (!isItOpened.isAWindowOpened)
            {
                StartCoroutine(DoubleClickStartCoroutine());
            }
        }


        IEnumerator DoubleClickStartCoroutine()
        {
            clickAmount += 1;
            yield break;
        }

        private void InitiateScan()
        {
            if (!isItOpened.isAWindowOpened)
            {
                StartCoroutine(StartingScanOfComputer());
            }
        }

        private void Update()
        {
            if (clickAmount >= clickChecker.amountOfClicks && GetComponent<Image>().sprite == thisSprite)
            {
                InitiateScan();
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

        IEnumerator StartingScanOfComputer()
        {
            isItOpened.isAWindowOpened = true;
            scanningWindow.SetActive(true);
            percentageText.SetActive(true);
            bugDeathSound.sfxSoundFiles[3].PlayAudio();
            percentageIndicatorText.text = "1%";
            percentageIndicators[0].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "5%";
            percentageIndicators[1].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "8%";
            percentageIndicators[2].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "12%";
            percentageIndicators[3].SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            percentageIndicatorText.text = "20%";
            percentageIndicators[4].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "29%";
            percentageIndicators[5].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "34%";
            percentageIndicators[6].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "40%";
            percentageIndicators[7].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "52%";
            percentageIndicators[8].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "59%";
            percentageIndicators[9].SetActive(true);
            yield return new WaitForSecondsRealtime(0.6f);
            percentageIndicatorText.text = "65%";
            percentageIndicators[10].SetActive(true);
            yield return new WaitForSecondsRealtime(0.4f);
            percentageIndicatorText.text = "69%";
            percentageIndicators[11].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "74%";
            percentageIndicators[12].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "79%";
            percentageIndicators[13].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "85%";
            percentageIndicators[14].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "92%";
            percentageIndicators[15].SetActive(true);
            yield return new WaitForSecondsRealtime(0.7f);
            percentageIndicatorText.text = "96%";
            percentageIndicators[16].SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            percentageIndicatorText.text = "98%";
            percentageIndicators[17].SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
            percentageIndicatorText.text = "99%";
            percentageIndicators[18].SetActive(true);
            yield return new WaitForSecondsRealtime(1.5f);
            scanningWindow.SetActive(false);
            percentageText.SetActive(false);
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
            childrenInParent = bugContainer.transform;
            childObjects = GetAllChildren(childrenInParent);
            numChildrenToDelete = Random.Range(0, childObjects.Length);
            totalBugFoundText.text = numChildrenToDelete.ToString("00") + " Bugs";
            foundBugsResultScreen.SetActive(true);
        }
        
        public void WipeBugs()
        {
            foundBugsResultScreen.SetActive(false);
            StartCoroutine(GetThemBugs());
            isItOpened.isAWindowOpened = false;
        }
        
        IEnumerator GetThemBugs()
        {
            bugDeathSound.sfxSoundFiles[0].PlayAudio();
            StartCoroutine(AddBugDeathsToTotal());
            StartCoroutine(CoolingDownNowMode());
            float originalBugMovementSpeed = bugMovementSpeed.bugSpeed;

            for (int i = 0; i < numChildrenToDelete; i++)
            {
                BugMovement bugMovement = childObjects[i].GetComponent<BugMovement>();
                ParticleSystem bugParticle = childObjects[i].GetComponent<ParticleSystem>();
                
                if (bugMovement != null)
                {
                    bugParticle.Play();
                    bugMovement.SetSpeed(bugMovementSpeed.bugSpeed);
                }

                yield return new WaitForSeconds(0.3f);
                Destroy(childObjects[i]);
                bugMovementSpeed.bugSpeed = originalBugMovementSpeed;
            }
        }

        IEnumerator AddBugDeathsToTotal()
        {
            addedTotal.totalBug += numChildrenToDelete;
            yield break;
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