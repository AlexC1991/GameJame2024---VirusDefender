using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class StoppedBugTimer : MonoBehaviour
    {
        [SerializeField] private NewDesktopWindow pausingTheSpawning;

        private void Awake()
        {
            pausingTheSpawning.pauseSpawning = false;
        }

        public bool StopTheSpawning()
        {
            StartCoroutine(StoppingSpawn());
            return false;
        }

        IEnumerator StoppingSpawn()
        {
            pausingTheSpawning.pauseSpawning = true;
            yield return new WaitForSeconds(12f);
            pausingTheSpawning.pauseSpawning = false;
            yield return null;
        }
    }
}
