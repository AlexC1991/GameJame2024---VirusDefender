using System;
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
        private int currentSpawnNumber;

        private void Awake()
        {
            currentSpawningSpeed = normalSpawningSpeed;
        }

        void Start()
        {
            checkingIfResetting.pauseSpawning = false;
            spawningFasteOrNot.infiteSpawning = false;
            spawningFasteOrNot.randomizedBackground = false;
            spawningFasteOrNot.spawnBugsFaster = false;
            currentLocation = transform;
            currentWeek.weekOfTheCurrent = 1;
            previousWeek = 1;
            spawnRateNumber = 10;
            StartCoroutine(SpawningBugsMain());
        }

        IEnumerator SpawningBugsMain()
        {
            Debug.Log("Spawning Bug Coroutine Has Started Checking" + checkingIfResetting.pauseSpawning);
           
            while (true)
            {
                if (!checkingIfResetting.pauseSpawning)
                {
                    Debug.Log("Still Spawning Bugs" + checkingIfResetting.pauseSpawning);

                    randomNumber = Random.Range(1, 999999);
                    totalBugCounter = GetAllChildren(bugStorageContainer.transform);
                    currentSpawnNumber = totalBugCounter.Length;

                    if (!spawningFasteOrNot.spawnBugsFaster && !spawningFasteOrNot.infiteSpawning &&
                        currentSpawnNumber != spawnRateNumber)
                    {
                        currentSpawningSpeed = normalSpawningSpeed;
                        yield return new WaitForSeconds(currentSpawningSpeed);
                        bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                        bug.transform.parent = bugStorageContainer.transform;
                        bug.transform.name = randomBugName + randomNumber;
                    }
                    else if (spawningFasteOrNot.spawnBugsFaster && !spawningFasteOrNot.infiteSpawning &&
                             currentSpawnNumber != spawnRateNumber)
                    {
                        currentSpawningSpeed = fastSpawning;
                        yield return new WaitForSeconds(currentSpawningSpeed);
                        bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                        bug.transform.parent = bugStorageContainer.transform;
                        bug.transform.name = randomBugName + randomNumber;
                    }
                    else if (spawningFasteOrNot.spawnBugsFaster && spawningFasteOrNot.infiteSpawning)
                    {
                        currentSpawningSpeed = fastSpawning;
                        yield return new WaitForSeconds(currentSpawningSpeed);
                        bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                        bug.transform.parent = bugStorageContainer.transform;
                        bug.transform.name = randomBugName + randomNumber;
                    }

                    if (currentWeek.weekOfTheCurrent > previousWeek)
                    {
                        spawnRateNumber += 10;
                        previousWeek = currentWeek.weekOfTheCurrent;
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
