using System;
using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class StartMenuOpenButton : MonoBehaviour
    {
        [SerializeField] private GameObject startMenuOpened;
        private int buttonCounter;

        private void Start()
        {
            buttonCounter = 0;
            startMenuOpened.SetActive(false);
        }


        public void StartMenuOpenerToggle()
        {
            StartCoroutine(ButtonPressingCounter());
        }
        

        private void OpenStartMenu()
        {
            startMenuOpened.SetActive(true);
        }

        private void CloseStartMenu()
        {
            startMenuOpened.SetActive(false);
        }

        private void Update()
        {
            if (buttonCounter == 1)
            {
                OpenStartMenu();
            }
            else if (buttonCounter == 2)
            {
                CloseStartMenu();
            }
            else if (buttonCounter > 2)
            {
                buttonCounter = 1;
            }
        }

        IEnumerator ButtonPressingCounter()
        {
            buttonCounter += 1;
            yield break;
        }
    }
}
