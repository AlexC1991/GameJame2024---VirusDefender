using System.Collections;
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
        private GameObject[] tileChildObjects;
        private GameObject[] bugChildObjects;
        private bool stillMoreToKill;

        private void Start()
        {
            stillMoreToKill = false;
            titleScreenMenu.SetActive(true);
            toolBar.SetActive(false);
            desktopResetButton.resetDesktop = false;
            desktopResetButton.endOfDayKillBugs = false;
        }

        private void Update()
        {
            if (desktopResetButton.resetDesktop || startingGameDay.gameStarted)
            {
                StartCoroutine(ResetDesktop());
                startingGameDay.gameStarted = false;
            }

            if (desktopResetButton.endOfDayKillBugs || startingGameDay.gameStarted)
            {
                StartCoroutine(GetThemBugs());
                startingGameDay.gameStarted = false;
            }
            
            bugChildObjects = GetAllChildren(bugParentContainer.transform);

            if (bugChildObjects.Length < 1)
            {
                stillMoreToKill = false;
            }
            else
            {
                stillMoreToKill = true;
            }
        }
        
        public void StartingGameNow()
        {
            startingGameDay.gameStarted = true;
            titleScreenMenu.SetActive(false);
            toolBar.SetActive(true);
        }

        IEnumerator ResetDesktop()
        {
            tileChildObjects = GetAllChildren(gameObject.transform);
            foreach (GameObject c in tileChildObjects)
            {
                c.GetComponent<Renderer>().sortingOrder = -1;
                desktopResetButton.resetDesktop = false;
            }
            yield break;
        }
        
        IEnumerator GetThemBugs()
        {
            bugChildObjects = GetAllChildren(bugParentContainer.transform);

            // Adjust numChildrenToDelete as needed
            int numChildrenToDelete = bugChildObjects.Length;

            for (int i = 0; i < numChildrenToDelete; i++)
            {
                GameObject bugObject = bugChildObjects[i];
                ParticleSystem particleSystem = bugObject.GetComponent<ParticleSystem>();
                bugObject.GetComponent<BugMovement>().movementSpeed = 0;

                // If it has a ParticleSystem component, play it
                if (particleSystem != null)
                {
                    particleSystem.Play();
                }

                // Wait for a short time to let the particle system play (you can adjust the duration if needed)
                yield return new WaitForSeconds(0.3f);
                Destroy(bugObject);
            }

            desktopResetButton.endOfDayKillBugs = false;
            stillMoreToKill = false;
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
