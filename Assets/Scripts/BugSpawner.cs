using System.Collections;
using UnityEngine;

namespace Batty251
{
    public class BugSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnGameBug;
        private Transform currentLocation;

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
                Instantiate(spawnGameBug, currentLocation.position, Quaternion.Euler(0, 0, 0));
            }
            
        }
    }
}
