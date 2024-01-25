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
        public GameObject[] tileChildObjects;
        private GameObject[] bugChildObjects;
        private int numChildrenToDelete;

        private void Start()
        {
            startingGameDay.gameStarted = false;
            titleScreenMenu.SetActive(true);
            toolBar.SetActive(false);
            desktopResetButton.resetDesktop = false;
            desktopResetButton.endOfDayKillBugs = false;
        }

        private void Update()
        {
            if (desktopResetButton.resetDesktop || startingGameDay.gameStarted)
            {
                StartCoroutine(StatingReset());
            }

            if (desktopResetButton.endOfDayKillBugs || startingGameDay.gameStarted)
            {
                StartCoroutine(StartingToClearBugs());
            }
            
            bugChildObjects = GetAllChildren(bugParentContainer.transform);
            tileChildObjects = GetAllChildren(gameObject.transform).Where(c => c.GetComponent<Renderer>().sortingOrder == 1).ToArray();
        }
        
        public void StartingGameNow()
        {
            startingGameDay.gameStarted = true;
            titleScreenMenu.SetActive(false);
            toolBar.SetActive(true);
        }

        IEnumerator StatingReset()
        {
            StartCoroutine(ResetDesktop());
            yield return new WaitForSeconds(0.5f);
            startingGameDay.gameStarted = false;
            desktopResetButton.resetDesktop = false;
        }

        IEnumerator StartingToClearBugs()
        {
            StartCoroutine(GetThemBugs());
            yield return new WaitForSeconds(0.5f);
            startingGameDay.gameStarted = false;
            desktopResetButton.endOfDayKillBugs = false;
        }

        IEnumerator ResetDesktop()
        {
            tileChildObjects = GetAllChildren(gameObject.transform).Where(c => c.GetComponent<Renderer>().sortingOrder == 1).ToArray();
            foreach (GameObject c in tileChildObjects)
            {
                c.GetComponent<Renderer>().sortingOrder = -1;
            }
            yield break;
        }
        
        IEnumerator GetThemBugs()
        {
            numChildrenToDelete = bugChildObjects.Length;
            
                for (int i = 0; i < numChildrenToDelete; i++)
                {
                    ParticleSystem particleSystem = bugChildObjects[i].GetComponent<ParticleSystem>();
                    bugChildObjects[i].GetComponent<BugMovement>().movementSpeed = 0;
                    if (particleSystem != null)
                    {
                        particleSystem.Play();
                    }
                    yield return new WaitForSeconds(0.3f);
                    Destroy(bugChildObjects[i]);
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
