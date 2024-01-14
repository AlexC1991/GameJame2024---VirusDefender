using UnityEngine;

namespace Batty251
{
    public class BugEatingWallpaperScript : MonoBehaviour
    {
        private bool hittingIt;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bug"))
            {
                Destroy(gameObject);
            }
        }
    }
    
}
