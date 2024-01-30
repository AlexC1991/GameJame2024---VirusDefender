using System;
using System.Collections;
using System.Linq;
using UnityEngine;
namespace Batty251
{
    public class DesktopReset : MonoBehaviour
    {
        [SerializeField] private NewDesktopWindow desktopResetButton;
        [SerializeField] private GameObject bugParentContainer;
        [SerializeField] private StartGameCheck startingGameDay;
        [SerializeField] private GameObject toolBar;
        [SerializeField] private GameObject titleScreenMenu;
        [SerializeField] private StatusEffects bugMovementSpeed;
        public GameObject[] tileChildObjects;
        private GameObject[] bugChildObjects;
        private int numChildrenToDelete;
        private bool enoughBugsToDelete;
        public int originalAmountOfTiles = 0;

        private void Start()
        {
            startingGameDay.gameStarted = false;
            titleScreenMenu.SetActive(true);
            toolBar.SetActive(false);
            desktopResetButton.resetDesktop = false;
            desktopResetButton.endOfDayKillBugs = false;
            StartCoroutine(GetThemBugs());
            StartCoroutine(NewDayAwaits());
            StartCoroutine(ResetDesktop());

        }
        
        public void StartingGameNow()
        {
            startingGameDay.gameStarted = true;
            titleScreenMenu.SetActive(false);
            toolBar.SetActive(true);
        }

        private void Update()
        {
            tileChildObjects = GetAllChildren(gameObject.transform).Where(c => c.GetComponent<Renderer>().sortingOrder == 1).ToArray();
        }

        IEnumerator ResetDesktop()
        {
            while (true)
            {
                if (desktopResetButton.resetDesktop)
                {
                    tileChildObjects = GetAllChildren(gameObject.transform).Where(c => c.GetComponent<Renderer>().sortingOrder == 1).ToArray();
                    GameObject[] tilesToReset = tileChildObjects.ToArray();  // Create a copy of the array

                    foreach (GameObject c in tilesToReset)
                    {
                        c.GetComponent<Renderer>().sortingOrder = -1;
                    }

                    if (tilesToReset.Length <= originalAmountOfTiles)
                    {
                        desktopResetButton.resetDesktop = false;
                    }
                }

                yield return null;
            }
        }
        
        IEnumerator GetThemBugs()
        {
            while (true)
            {
                if (desktopResetButton.endOfDayKillBugs)
                {
                    bugChildObjects = GetAllChildren(bugParentContainer.transform);
                    numChildrenToDelete = bugChildObjects.Length;

                    float originalBugMovementSpeed = bugMovementSpeed.bugSpeed;

                    for (int i = 0; i < numChildrenToDelete; i++)
                    {
                        BugMovement bugMovement = bugChildObjects[i].GetComponent<BugMovement>();

                        if (bugMovement != null)
                        {
                            bugMovement.SetSpeed(bugMovementSpeed
                                .bugSpeed); // Assuming you have a method in BugMovement to set the speed
                        }

                        if (bugChildObjects.Length > 0)
                        {
                            yield return new WaitForSeconds(0.001f);
                            Destroy(bugChildObjects[i]);
                            bugMovementSpeed.bugSpeed = originalBugMovementSpeed;
                        }
                        else
                        {
                            desktopResetButton.endOfDayKillBugs = false;
                        }
                    }
                }

                yield return null;
            }
        }


        IEnumerator NewDayAwaits()
        {
            while (true)
            {
                if (startingGameDay.gameStarted)
                {
                    desktopResetButton.pauseSpawning = true;
                    bugChildObjects = GetAllChildren(bugParentContainer.transform);
                    numChildrenToDelete = bugChildObjects.Length;

                    float originalBugMovementSpeed = bugMovementSpeed.bugSpeed;

                    for (int i = 0; i < numChildrenToDelete; i++)
                    {
                        BugMovement bugMovement = bugChildObjects[i].GetComponent<BugMovement>();

                        if (bugMovement != null)
                        {
                            bugMovement.SetSpeed(bugMovementSpeed
                                .bugSpeed); // Assuming you have a method in BugMovement to set the speed
                        }

                        if (bugChildObjects.Length > 0)
                        {
                            yield return new WaitForSeconds(0.001f);
                            Destroy(bugChildObjects[i]);
                            bugMovementSpeed.bugSpeed = originalBugMovementSpeed;
                        }
                    }

                    yield return new WaitForSeconds(0.1f);
                    tileChildObjects = GetAllChildren(gameObject.transform).Where(c => c.GetComponent<Renderer>().sortingOrder == 1).ToArray();
                    GameObject[] tilesToReset = tileChildObjects.ToArray();  // Create a copy of the array

                    foreach (GameObject c in tilesToReset)
                    {
                        c.GetComponent<Renderer>().sortingOrder = -1;
                    }

                    if (tilesToReset.Length <= originalAmountOfTiles)
                    {
                        desktopResetButton.pauseSpawning = false;
                        startingGameDay.gameStarted = false;
                    }
                }

                yield return null;
            }
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
