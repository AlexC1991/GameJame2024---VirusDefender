using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class DateAndTimeScript : MonoBehaviour
    {
        [SerializeField] private Text dateAndTimeDisplay;
        private String whatDay;
        private int hourDay;
        private int minuteDay;
        private string showZeroM;
        private string showZeroH;
        private Coroutine minuteTrackerCoroutine;
        
        private void Start()
        {
            showZeroM = "0";
            showZeroH = "0";
            whatDay = "Mon";
            hourDay = 8;
            minuteDay = 0;
            minuteTrackerCoroutine = StartCoroutine(MinuteTracker());
        }

        IEnumerator MinuteTracker()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.8f);
                minuteDay += 1;
                if (minuteDay >= 59)
                {
                    minuteDay = 0;
                    hourDay += 1;
                }
                dateAndTimeDisplay.text = whatDay + " " + showZeroH + hourDay + ":" + showZeroM + minuteDay;
            }
        }

        private void Update()
        {
            if (hourDay >= 16)
            {
                StopCoroutine(minuteTrackerCoroutine);
                minuteDay = 0;
            }

            if (hourDay > 9)
            {
                showZeroH = "";
            }
            else if (hourDay >= 0 && hourDay <= 9)
            {
                showZeroH = "0";
            }
            
            if (minuteDay > 9)
            {
                showZeroM = "";
            }
            else if (minuteDay >= 0 && minuteDay <= 9)
            {
                showZeroM = "0";
            }
        }
    }
}