using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class DateAndTimeScript : MonoBehaviour
    {
        [SerializeField] private DayAndWeekTrackerContainer whatDayAndWeekIsIt;
        [SerializeField] private Text dateAndTimeDisplay;
        [SerializeField] private GameObject clipBoard;
        [SerializeField] private Text weekText;
        [SerializeField] private Text dayText;
        [SerializeField] private NewDesktopWindow desktopResetButton;
        [SerializeField] private ClipBoardDisplay clipBoardDataStart;
        [SerializeField] private ClipBoardSaveData savedClipBoardData;
        [SerializeField] private DayAndWeekTrackerContainer randomBool;
        private String whatDay;
        private int hourDay;
        private int minuteDay;
        private string showZeroM;
        private string showZeroH;
        private Coroutine minuteTrackerCoroutine;
        private int switchNumber;
        private int weekNumber;
        private string weekName = "Week: ";
        private string fullDayName;
        private string dayStartText = "Day: ";
        private bool activateOnce;
        private bool isClipBoardDisplayed = false;
        private int dayCounter;
        private float totalTimeInGame;

        private void Awake()
        {
            clipBoard.SetActive(false);
        }

        private void Start()
        {
            whatDayAndWeekIsIt.dayOfTheWeek = 1;
            whatDayAndWeekIsIt.weekOfTheCurrent = 1;
            weekNumber = whatDayAndWeekIsIt.weekOfTheCurrent;
            switchNumber = whatDayAndWeekIsIt.dayOfTheWeek;
            DayChanger();
            StartOfDay();
        }

        IEnumerator MinuteTracker()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.4f);
                minuteDay += 1;
                if (minuteDay > 59)
                {
                    minuteDay = 0;
                    hourDay += 1;
                }
                StartCoroutine(UpdateTime());
            }
        }

        IEnumerator UpdateTime()
        {
            dateAndTimeDisplay.text = whatDay + " " + showZeroH + hourDay + ":" + showZeroM + minuteDay;
            yield break;
        }

        private void Update()
        {
            if (hourDay >= 16 && !isClipBoardDisplayed) // Check if clipboard is not displayed yet
            {
                minuteDay = 0;
                showZeroM = "0";
                StartCoroutine(UpdateTime());
                StartCoroutine(DisplayClipBoard());
                StopCoroutine(minuteTrackerCoroutine);
                isClipBoardDisplayed = true; // Set the flag to true to indicate clipboard is displayed
            }

            if (hourDay >= 10)
            {
                showZeroH = "";
            }
            else if (hourDay < 10)
            {
                showZeroH = "0";
            }
            
            if (minuteDay >= 9)
            {
                showZeroM = "";
            }
            else if (minuteDay < 10)
            {
                showZeroM = "0";
            }

            if (minuteDay == 0)
            {
                showZeroM = "0";
                StartCoroutine(UpdateTime());
            }

            totalTimeInGame += Time.deltaTime;
            savedClipBoardData.totalTimePlayed = totalTimeInGame;
        }

        public void NextDay()
        {
            randomBool.changeWallpaperIfRandom = true;
            desktopResetButton.resetDesktop = true;
            isClipBoardDisplayed = false;
            
            if (switchNumber < 5)
            {
                switchNumber += 1;
                whatDayAndWeekIsIt.dayOfTheWeek = switchNumber;
            }
            else
            {
                weekNumber += 1;
                switchNumber = 1;
                whatDayAndWeekIsIt.dayOfTheWeek = switchNumber;
                whatDayAndWeekIsIt.weekOfTheCurrent = weekNumber;
            }
            
            DayChanger();
            clipBoard.SetActive(false);
            StartOfDay();
        }

        private void DayChanger()
        {
            switch (switchNumber)
            {
                case 1:
                    whatDay = "Mon";
                    fullDayName = "Monday";
                    break;
                case 2:
                    whatDay = "Tues";
                    fullDayName = "Tuesday";
                    break;
                case 3:
                    whatDay = "Wed";
                    fullDayName = "Wednesday";
                    break;
                case 4:
                    whatDay = "Thur";
                    fullDayName = "Thursday";
                    break;
                case 5:
                    whatDay = "Fri";
                    fullDayName = "Friday";
                    break;
            }
        }

        private void StartOfDay()
        {
            minuteTrackerCoroutine = StartCoroutine(MinuteTracker());
            hourDay = 8;
            minuteDay = 0;
        }

        IEnumerator DisplayClipBoard()
        {
            Debug.Log("DisplayClipBoard Continously Being Called");
            dayCounter += 1;
            savedClipBoardData.totalDaysPlayed = dayCounter;
            clipBoard.SetActive(true);
            clipBoardDataStart.EndOfDayDisplayed();
            dayText.text = dayStartText + fullDayName;
            weekText.text = weekName + weekNumber;
            desktopResetButton.endOfDayKillBugs = true;
            yield break;
        }
    }
}