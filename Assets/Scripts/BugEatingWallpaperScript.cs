using System.Collections;
using UnityEngine;

namespace Batty251
{
    public class BugEatingWallpaperScript : MonoBehaviour
    {
        private bool hittingIt;
        [SerializeField] private WallCollisionDataContainer wallC;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bug"))
            {
                hittingIt = true;
            }
        }

        private void Update()
        {
            if (hittingIt)
            {
                StartCoroutine(SendDataBeforeDeath());
                hittingIt = false;
            }
        }

        IEnumerator SendDataBeforeDeath()
        {
            wallC.hitWall = true;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Renderer>().sortingOrder = 2;
        }
    }
    
}
