using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class StatisticsWindow : MonoBehaviour
    {
        [SerializeField] private Text totalNumberOfTimeInGame;
        [SerializeField] private Text totalNumberOfMoney;
        [SerializeField] private Text totalNumberOfBugsKilled;
        [SerializeField] private Text totalNumberOfDaysPlayed;
        [SerializeField] private ClipBoardSaveData savedData;
        [SerializeField] private GameObject statisticsMenu;

        private void Awake()
        {
            statisticsMenu.SetActive(false);
            savedData.moneyTotal = 0;
            savedData.percentageLeft = 0;
            savedData.bugNumberKilled = 0;
            savedData.gradeStatusBest = 0;
            savedData.gradeStatusNormal = 0;
            savedData.gradeStatusBad = 0;
            savedData.totalDaysPlayed = 0;
            savedData.totalTimePlayed = 0;
        }

        private void FixedUpdate()
        {
            totalNumberOfTimeInGame.text = "Total Time Played: " + savedData.totalTimePlayed.ToString("00");
            totalNumberOfMoney.text = "Total Money Earned: " + savedData.moneyTotal.ToString("00");
            totalNumberOfBugsKilled.text = "Total Bugs Killed: " + savedData.bugNumberKilled.ToString("00");
            totalNumberOfDaysPlayed.text = "Total Days In Game: " + savedData.totalDaysPlayed.ToString("00");
        }

        public void OpenStatisticsMenu()
        {
            Time.timeScale = 0;
            statisticsMenu.SetActive(true);
        }

        public void CloseStatisticsMenu()
        {
            Time.timeScale = 1;
            statisticsMenu.SetActive(false);
        }
    }
}
