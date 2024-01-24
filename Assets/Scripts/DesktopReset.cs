using System;
using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class DesktopReset : MonoBehaviour
    {
        [SerializeField] private NewDesktopWindow desktopResetButton;
        [SerializeField] private GameObject bugParentContainer;
        private GameObject[] tileChildObjects;
        private GameObject[] bugChildObjects;


        private void Start()
        {
            desktopResetButton.resetDesktop = false;
            desktopResetButton.endOfDayKillBugs = false;
        }

        private void FixedUpdate()
        {
            if (desktopResetButton.resetDesktop)
            {
                StartCoroutine(ResetDesktop());
            }

            if (desktopResetButton.endOfDayKillBugs)
            {
                StartCoroutine(GetThemBugs());
            }
            
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
                
             foreach (var t in bugChildObjects)
             {
                 ParticleSystem particleSystem = t.GetComponent<ParticleSystem>();
                 t.GetComponent<BugMovement>().movementSpeed = 0;
                 // If it has a ParticleSystem component, play it
                 if (particleSystem != null)
                 {
                     particleSystem.Play();
                 }
                 yield return new WaitForSeconds(0.3f);
                 Destroy(t);
             }

             desktopResetButton.endOfDayKillBugs = false;
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
