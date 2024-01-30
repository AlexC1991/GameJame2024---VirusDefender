using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class ClipBoardDisplay : MonoBehaviour
    {
        [SerializeField] private Sprite[] facesToDisplay;
        [SerializeField] private Text moneyTextDisplayed;
        [SerializeField] private ClipBoardSaveData saveClipBoardData;
        [SerializeField] private Text faceTextToDisplay;
        [SerializeField] private Image whatFaceToDisplay;
        [SerializeField] private BugTotalContainer totalBugsInToolBar;
        [SerializeField] private MusicScriptableObject coinSound;
        [SerializeField] private NewDesktopWindow pauseSpawning;
        [SerializeField] private WindowsOpen endOfDayOpened;
        private int _gradeNumber;
        public float _moneyTotal;
        private float _totalForGrade;
        private bool _isSpinning;
        
        private void Awake()
        {
            _isSpinning = false;
        }

        public bool EndOfDayDisplayed()
        {
            StartCoroutine(DisplayTextAndSaveFunction());
            pauseSpawning.pauseSpawning = true;
            endOfDayOpened.isAWindowOpened = true;
            Debug.Log("Bool To Start It ALl Being Called Still");
            return false;
        }

        IEnumerator DisplayTextAndSaveFunction()
        {
            _totalForGrade = 0; // Reset _totalForGrade at the beginning of each call

            _totalForGrade += saveClipBoardData.percentageLeft + totalBugsInToolBar.totalBug;
            
            Debug.Log("Display Text Function Being Called");

            float percentage = (_totalForGrade / 100.0f) * 100;

            if (percentage >= 70)
            {
                _gradeNumber = 1;
                saveClipBoardData.gradeStatusBest += 1;
                WhatGradeSwitchStatement();
            }
            else if (percentage >= 40)
            {
                _gradeNumber = 2;
                saveClipBoardData.gradeStatusNormal += 1;
                WhatGradeSwitchStatement();
            }
            else
            {
                _gradeNumber = 3;
                saveClipBoardData.gradeStatusBad += 1;
                WhatGradeSwitchStatement();
            }

            yield return null;
        }
        
        private void WhatGradeSwitchStatement()
        {
            switch (_gradeNumber)
            {
                case 1:
                    whatFaceToDisplay.sprite = facesToDisplay[0];
                    faceTextToDisplay.text = "Great Work!";
                    _moneyTotal += 100;
                    saveClipBoardData.moneyTotal += 100;
                    saveClipBoardData.bugNumberKilled += totalBugsInToolBar.totalBug;
                    totalBugsInToolBar.totalBug = 0;
                    StartCoroutine(MoneyDisplayText());
                    break;
                case 2:
                    whatFaceToDisplay.sprite = facesToDisplay[1];
                    faceTextToDisplay.text = "Nice Job";
                    _moneyTotal += 50;
                    saveClipBoardData.moneyTotal += 50;
                    saveClipBoardData.bugNumberKilled += totalBugsInToolBar.totalBug;
                    totalBugsInToolBar.totalBug = 0;
                    StartCoroutine(MoneyDisplayText());
                    break;
                case 3:
                    whatFaceToDisplay.sprite = facesToDisplay[2];
                    faceTextToDisplay.text = "Do Better Tomorrow..";
                    _moneyTotal += 5;
                    saveClipBoardData.moneyTotal += 5;
                    saveClipBoardData.bugNumberKilled += totalBugsInToolBar.totalBug;
                    totalBugsInToolBar.totalBug = 0;
                    StartCoroutine(MoneyDisplayText());
                    break;
            }
        }
        IEnumerator MoneyDisplayText()
        {
            coinSound.sfxSoundFiles[4].PlayAudio();
            _isSpinning = true;
            int spinDuration = 8;
            int spinSpeed = 5;

            float targetTotal = _moneyTotal; // The final total you want to reach
            int currentTotal = 0;

            for (int i = 0; i < spinDuration; i++)
            {
                int randomDigit = Random.Range(0, 10);
                currentTotal += randomDigit;

                moneyTextDisplayed.text = "Total Money Earned A Total Of: " + "$"+ currentTotal.ToString("00");
                Debug.Log("MoneyDisplayText Continously Being Called");
                yield return new WaitForSeconds(1f / spinSpeed);
            }
            moneyTextDisplayed.text = "Total Money Earned A Total Of: " + "$" + targetTotal;
            _isSpinning = false;
        }
    }
}
