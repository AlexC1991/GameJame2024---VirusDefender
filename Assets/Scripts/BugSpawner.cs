using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Batty251
{
    public class BugSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnGameBug;
        private Transform currentLocation;
        [SerializeField] private GameObject bugStorageContainer;
        private string randomBugName = "Bug";
        private GameObject bug;
        private int randomNumber;

        void Start()
        {
            StartCoroutine(SpawnBug());
            currentLocation = transform;
        }

        IEnumerator SpawnBug()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
               bug = Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
                bug.transform.parent = bugStorageContainer.transform;
                bug.transform.name = randomBugName + randomNumber;
            }
            
        }
        
        private void Update()
        {
            randomNumber = Random.Range(1, 999999);
        }
    }
}
