using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "Day&WeekContainerInfo", menuName = "DataContainers/Day&WeekContainerInfo")]
    public class DayAndWeekTrackerContainer : ScriptableObject
    {
        public int dayOfTheWeek;
        public int weekOfTheCurrent;
        public bool changeWallpaperIfRandom;
    }
}
