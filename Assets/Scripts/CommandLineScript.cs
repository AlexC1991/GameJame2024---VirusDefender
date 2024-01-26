using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Batty251
{
    public class CommandLineScript : MonoBehaviour
    {
        [SerializeField] private InputField inputFieldParent;
        [SerializeField] private Text outputTextPrefab;
        private int _sections;
        [SerializeField] private WindowsOpen isItOpened;
        [SerializeField] private SettingsMenuContainer clickChecker;
        private int clickAmount;
        private string currentDirectory = "SecurityComputer:/";
        [SerializeField] private NewDesktopWindow deskTopRepair;
        [SerializeField] private StatusEffects addSlowEffect;
        [SerializeField] private GameObject bugContainer;
        [SerializeField] private BugHealth _bugHealth;
        private GameObject[] bugChildren;
        [SerializeField] private NewDesktopWindow pausingTheSpawning;
        
        private void Start()
        {
            _sections = 1;
        }

        public void StartConsoleWindow()
        {
                StartCoroutine(StartConsoleLine());
        }

        private void OnInputValueChanged()
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                    inputFieldParent.text = currentDirectory;
                    inputFieldParent.selectionAnchorPosition = inputFieldParent.caretPosition;
                    inputFieldParent.selectionFocusPosition = inputFieldParent.caretPosition;
                    inputFieldParent.caretPosition = inputFieldParent.text.Length;
            }
        }
        
        IEnumerator StartConsoleLine()
        {
            deskTopRepair.resetDesktop = false;
            isItOpened.isAWindowOpened = true;
            inputFieldParent.text = "";
            inputFieldParent.text += currentDirectory;
            inputFieldParent.ActivateInputField();
            _sections = 0;
            inputFieldParent.Select();
            yield return new WaitForSeconds(0.001f);
            inputFieldParent.selectionAnchorPosition = inputFieldParent.caretPosition;
            inputFieldParent.selectionFocusPosition = inputFieldParent.caretPosition;
            inputFieldParent.caretPosition = inputFieldParent.text.Length;
            inputFieldParent.MoveTextEnd(false);
        }

        private void Update()
        {
            bool isInputAllowed = inputFieldParent.text == currentDirectory;
            
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

            if (isInputAllowed && _sections != 1)
            {
                if (Input.GetButton("Horizontal"))
                {
                    StartCoroutine(StartConsoleLine());
                }
                else if (Input.GetButton("Vertical"))
                {
                    StartCoroutine(StartConsoleLine());
                }

                if (Input.GetKey(KeyCode.Backspace) && isInputAllowed && _sections == 1)
                {
                    OnInputValueChanged();
                }
            }

            if (inputFieldParent.text != currentDirectory && _sections == 1)
            {
                OnInputValueChanged();
            }
        }
        private void CommandLinePrompt()
        {
            string trimmedInput = inputFieldParent.text.Trim();

            if (trimmedInput.Equals("SecurityComputer:/Help", StringComparison.OrdinalIgnoreCase)) {
                StartCoroutine(HelpChannel());
                _sections = 2;
            }
            else if (trimmedInput.Equals("SecurityComputer:/Repair System", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(ReapirChannel());
                _sections = 4;
            }
            else if (trimmedInput.Equals("SecurityComputer:/USB Power Reboot", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(PowerRebootChannel());
                _sections = 5;
            }
            else if (trimmedInput.Equals("SecurityComputer:/USB Data Transfer", StringComparison.OrdinalIgnoreCase))
            {
                StartCoroutine(DataTransferChannel());
                _sections = 6;
            }
            else if (string.IsNullOrEmpty(trimmedInput)) {
                inputFieldParent.text = currentDirectory;
            }
            else
            {
                _sections = 3;
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
            inputFieldParent.text += "\n" + "\n" + "USB Power Reboot/usb power reboot = Temporary Stops the USB From Producing More Viruses Onto The System";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text += "\n" + "\n" +  "USB Data Transfer/usb data transfer = Slowdown The USB Drive and Does  Damage To Any Viruses Coming From It";
            yield return new WaitForSeconds(0.4f);
            inputFieldParent.text += "\n" + "\n" +  "Please Press Return/Enter To Continue";
            _sections = 1;
        }

        IEnumerator ErrorChannel()
        {
            inputFieldParent.text = "Error Wrong Code";
            inputFieldParent.text += " \n \n Can Not Find That Interaction/Instructions";
            yield return new WaitForSeconds(0.2f);
            inputFieldParent.text += " \n \n \n \n \n Press the Enter/Return Key To Go Back";
            _sections = 1;
        }

        IEnumerator ReapirChannel()
        {
            inputFieldParent.text = "Commencing Repair On System";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text += " \n \n Scanning.";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text = "Scanning..";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text = "Scanning...";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text += " \n \n Commencing Repair Now";
            yield return new WaitForSeconds(0.3f);
            inputFieldParent.text += " \n \n \n |----------------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||----------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||---------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||--------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||-------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||------------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||-----------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||----------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||||---------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||||--------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||||||-------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||||||------";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||||||||-----";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||||||||----";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||||||||||---";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||||||||||--";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "|||||||||||||||||-";
            yield return new WaitForSeconds(0.1f);
            inputFieldParent.text = "||||||||||||||||||";
            yield return new WaitForSeconds(0.3f);
            deskTopRepair.resetDesktop = true;
            inputFieldParent.text += " \n \n \n Desktop Has been Repaired";
            inputFieldParent.text += " \n \n \n \n \n Press the Enter/Return Key To Go Back";
            _sections = 1;
        }

        IEnumerator DataTransferChannel()
        {
            bugChildren = GetAllChildren(bugContainer.transform);
            float  bugHealthDamage = Random.Range(_bugHealth.virusBugDamageMin, _bugHealth.virusBugDamageMax);
            float originalBugSpeed = addSlowEffect.bugSpeed;
            inputFieldParent.text = "Starting Damage On USB Bugs";
            yield return new WaitForSeconds(0.5f);
            inputFieldParent.text += "\n \n Starting Overload of Bugs";
            yield return new WaitForSeconds(0.5f);
            addSlowEffect.bugSpeed = 0.1f;
            foreach (var g in bugChildren)
            {
                g.GetComponent<DynamicHealthIndicator>().TakeDamage(bugHealthDamage);
            }
            inputFieldParent.text += "\n \n  Overloading In Process..";
            yield return new WaitForSeconds(0.1f);
            foreach (var g in bugChildren)
            {
                g.GetComponent<DynamicHealthIndicator>().TakeDamage(bugHealthDamage);
            }
            inputFieldParent.text += "\n \n Continuing Effect..";
            foreach (var g in bugChildren)
            {
                g.GetComponent<DynamicHealthIndicator>().TakeDamage(bugHealthDamage);
            }
            yield return new WaitForSeconds(0.1f);
            addSlowEffect.bugSpeed = originalBugSpeed;
            inputFieldParent.text += "\n \n \n \n Finished Unloading Data Transfer Attack..";
            inputFieldParent.text += " \n \n \n \n \n Press the Enter/Return Key To Go Back";
            _sections = 1;
        }

        IEnumerator PowerRebootChannel()
        {
            inputFieldParent.text = "Starting To Power Down Infested USB Device..";
            yield return new WaitForSeconds(0.5f);
            pausingTheSpawning.pauseSpawning = true;
            yield return new WaitForSeconds(0.5f);
            inputFieldParent.text = "\n \n \n Rebooting In Progress..";
            yield return new WaitForSeconds(0.2f);
            inputFieldParent.text += "\n \n \n \n In T-minus 2 minute.. ";
            yield return new WaitForSeconds(0.2f);
            inputFieldParent.text += " \n \n \n \n \n Press the Enter/Return Key To Go Back";
            StartCoroutine(RebootBackUp());
            _sections = 1;
        }

        IEnumerator RebootBackUp()
        {
            yield return new WaitForSeconds(8f);
            pausingTheSpawning.pauseSpawning = false;
        }
        
        private GameObject[] GetAllChildren(Transform parent)
        {
            int childCount = parent.childCount;
            GameObject[] children = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                Transform child = parent.GetChild(i);
                children[i] = child.gameObject;
            }

            return children;
        }
    }
    
}
