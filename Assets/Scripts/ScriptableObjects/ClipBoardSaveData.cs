using UnityEngine;
namespace Batty251
{
    [CreateAssetMenu(fileName = "ClipBoardSaveContainer", menuName = "DataContainers/ClipBoardSaveContainer")]
    public class ClipBoardSaveData : ScriptableObject
    {
        public float moneyTotal;
        public int gradeStatusBest;
        public int gradeStatusNormal;
        public int gradeStatusBad;
        public float percentageLeft;
        public int bugNumberKilled;
        public float totalTimePlayed;
        public int totalDaysPlayed;
    }
}
