using System;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class BugCounterScript : MonoBehaviour
    {
        [SerializeField] private Text bugKilledCounter;
        [SerializeField] private BugTotalContainer totalShowing;

        private void Start()
        {
            totalShowing.totalBug = 0;
        }

        private void Update()
        {
            bugKilledCounter.text = "Bugs Killed \n " + "       " +totalShowing.totalBug.ToString("00");
        }
    }
}
