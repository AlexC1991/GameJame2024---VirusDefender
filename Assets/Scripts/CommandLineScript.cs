using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Batty251
{
    public class CommandLineScript : MonoBehaviour
    {
        [SerializeField] private InputField inputFieldParent;
        [SerializeField] private Text outputTextPrefab;
        private int _sections;
        [SerializeField] private WindowsOpen isItOpened;
        
        private string currentDirectory = "SecurityComputer:/";

        public void StartConsoleWindow()
        {
            StartCoroutine(StartConsoleLine());
            inputFieldParent.onValueChanged.AddListener(OnInputValueChanged);
        }

        private void OnInputValueChanged(string text)
        {
            // Check for Backspace key in the input and prevent it
            if (Input.GetKeyDown(KeyCode.Backspace)) {
                inputFieldParent.text = currentDirectory;
                inputFieldParent.selectionAnchorPosition = inputFieldParent.caretPosition;
                inputFieldParent.selectionFocusPosition = inputFieldParent.caretPosition;
                inputFieldParent.caretPosition = inputFieldParent.text.Length;
            }
        }
        
        IEnumerator StartConsoleLine()
        {
            isItOpened.isAWindowOpened = true;
            _sections = 0;
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text = "";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text += currentDirectory;
            yield return new WaitForSeconds(0.2f);
            inputFieldParent.ActivateInputField();
            yield return new WaitForSeconds(0.001f);
            inputFieldParent.Select();
            inputFieldParent.selectionAnchorPosition = inputFieldParent.caretPosition;
            inputFieldParent.selectionFocusPosition = inputFieldParent.caretPosition;
            inputFieldParent.caretPosition = inputFieldParent.text.Length;
            inputFieldParent.MoveTextEnd(false);
            inputFieldParent.onValueChanged.AddListener(OnInputValueChanged);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (_sections == 0)
                {
                    StartCoroutine(ResultsFromCode());
                }
                else if (_sections == 1)
                {
                    StartCoroutine(StartConsoleLine());
                }
            }
        }

        private void CommandLinePrompt()
        {
            string trimmedInput = inputFieldParent.text.Trim();

            if (trimmedInput.Equals("SecurityComputer:/Help", StringComparison.OrdinalIgnoreCase)) {
                StartCoroutine(HelpChannel());
                _sections = 1;
            }
            else if (string.IsNullOrEmpty(trimmedInput)) {
                inputFieldParent.text = currentDirectory;
            }
            else
            {
                _sections = 1;
                StartCoroutine(ErrorChannel());
            }
            if (inputFieldParent.text == "") {
                inputFieldParent.text = currentDirectory;
            }
        }

        IEnumerator ResultsFromCode()
        {
            yield return new WaitForSeconds(0.1f);
            CommandLinePrompt();
        }

        IEnumerator HelpChannel()
        {
            inputFieldParent.text = "This is your Help Channel";  
            inputFieldParent.text += "\n" + "Use The Following Commands";
            inputFieldParent.text += "\n" + "\n" + "Help/help = Help Channel";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text += "\n" + "\n" + "Repair System/repair system = Repair Degraded System From Bugs";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text += "\n" + "\n" + "USB Reboot/usb reboot = Stops the USB From Producing More Viruses  Onto The System";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text += "\n" + "\n" +  "USB Power Reboot/usb power reboot = Damages THe USB And  Any Viruses Infesting The PC From It";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text += "\n" + "\n" +  "USB Data Transfer/usb data transfer = Slowdown The USB Drive and Does  Damage To Any Viruses Coming From It";
            yield return new WaitForSeconds(0.4f);
            inputFieldParent.text += "\n" + "\n" +  "Please Press Return/Enter To Continue";
        }

        IEnumerator ErrorChannel()
        {
            inputFieldParent.text = "Error Wrong Code";
            inputFieldParent.text += " \n \n Can Not Find That Interaction/Instructions";
            yield return new WaitForSeconds(0.2f);
            inputFieldParent.text += " \n \n \n \n \n Press the Enter/Return Key To Go Back";
        }
    }
}
