using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Batty251
{
    public class CommandLineScript : MonoBehaviour
    {
        public InputField inputFieldParent; // Drag and drop an empty GameObject here in the Unity Editor
        public Text outputTextPrefab; // Drag and drop a Text UI element here in the Unity Editor
        
        private string currentDirectory = "SecurityComputer:/";

        private void Start()
        {
            inputFieldParent.text = currentDirectory;
            StartCoroutine(StartConsoleLine());
        }

        IEnumerator StartConsoleLine()
        {
            inputFieldParent.ActivateInputField();
            yield return new WaitForSeconds(0.1f);
            Input.GetMouseButtonDown(0);
        }

        private void Update()
        {
            // Check if the Enter key is pressed
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // Clear the outputTextPrefab text
                outputTextPrefab.text = "";
                
                // Append the outputTextPrefab text to the inputFieldParent text
                inputFieldParent.text += "\n" + outputTextPrefab.text;
            }
        }
    }


}
