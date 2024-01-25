using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Batty251
{
    public class BugSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnGameBug;
        private Transform currentLocation;
        [SerializeField] private GameObject bugStorageContainer;
        [SerializeField] private DayAndWeekTrackerContainer currentWeek;
        [SerializeField] [CanBeNull] private SettingsMenuContainer spawningFasteOrNot;
        [SerializeField] private NewDesktopWindow checkingIfResetting;
        private float fastSpawning = 1f;
        private float normalSpawningSpeed = 6;
        private float currentSpawningSpeed;
        private int previousWeek;
        private string randomBugName = "Bug";
        private GameObject bug;
        private int randomNumber;
        private GameObject[] totalBugCounter;
        private int spawnRateNumber;
        private bool isSpawning;

        void Start()
        {
            spawningFasteOrNot.infiteSpawning = false;
            spawningFasteOrNot.randomizedBackground = false;
            spawningFasteOrNot.spawnBugsFaster = false;
            currentLocation = transform;
            previousWeek = currentWeek.weekOfTheCurrent;
            spawnRateNumber = 10;
            StartCoroutine(StartOfChecks());
        }
        
        IEnumerator StartOfChecks()
        {
            yield return new WaitForSeconds(currentSpawningSpeed);
            StartCoroutine(CheckHowManyChildren());
            StartCoroutine(ChangeSpawnSpeed());
            StartCoroutine(CheckInfiniteSpawning());
        }

        IEnumerator NormalSpawningBugs()
        {
            if (!checkingIfResetting.resetDesktop && !checkingIfResetting.endOfDayKillBugs)
            {
                bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                bug.transform.parent = bugStorageContainer.transform;
                bug.transform.name = randomBugName + randomNumber;
            }
            yield return null;
        }
        
        private void Update()
        {
            randomNumber = Random.Range(1, 999999);
            
            if (spawningFasteOrNot.spawnBugsFaster)
            {
                currentSpawningSpeed = fastSpawning;
            }
            else
            {
                currentSpawningSpeed = normalSpawningSpeed;
            }

            if (currentWeek.weekOfTheCurrent > previousWeek)
            {
                spawnRateNumber += 10;
                previousWeek = currentWeek.weekOfTheCurrent;
            }
        }

        IEnumerator CheckInfiniteSpawning()
        {
            while (true)
            {
                yield return new WaitForSeconds(currentSpawningSpeed);

                if (!checkingIfResetting.resetDesktop && !checkingIfResetting.endOfDayKillBugs)
                {
                    if (spawningFasteOrNot.infiteSpawning && !isSpawning)
                    {
                        isSpawning = true;
                        StartCoroutine(SpawnInfiniteBugs());
                    }
                    else if (!spawningFasteOrNot.infiteSpawning && isSpawning)
                    {
                        isSpawning = false;
                        StopCoroutine(SpawnInfiniteBugs());
                    }
                }
            }
        }

        IEnumerator ChangeSpawnSpeed()
        {
            while (true)
            {
                yield return new WaitForSeconds(currentSpawningSpeed);
                
                if (spawningFasteOrNot.spawnBugsFaster)
                {
                    currentSpawningSpeed = fastSpawning;
                }
                else
                {
                    currentSpawningSpeed = normalSpawningSpeed;
                }
                
            }
        }

        IEnumerator CheckHowManyChildren()
        {
            while (true)
            {
                yield return new WaitForSeconds(currentSpawningSpeed);
               
                if (!checkingIfResetting.resetDesktop && !checkingIfResetting.endOfDayKillBugs)
                {
                    if (!spawningFasteOrNot.infiteSpawning && !isSpawning)
                    {
                        totalBugCounter = GetAllChildren(bugStorageContainer.transform);

                        if (totalBugCounter.Length < spawnRateNumber)
                        {
                            StartCoroutine(NormalSpawningBugs());
                        }
                    }
                }
            }
        }
        
        IEnumerator SpawnInfiniteBugs()
        {
            while (isSpawning)
            {
                if (!checkingIfResetting.resetDesktop && !checkingIfResetting.endOfDayKillBugs)
                {
                    bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                    bug.transform.parent = bugStorageContainer.transform;
                    bug.transform.name = randomBugName + randomNumber;
                }
                yield return new WaitForSeconds(currentSpawningSpeed); // Introduce a delay here
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
