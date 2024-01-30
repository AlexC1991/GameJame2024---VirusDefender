using System;
using System.Collections;
using UnityEngine;
namespace Batty251
{
    public class BugIssues : MonoBehaviour
    {
        private GameObject[] childinParent;
        private BugMovement bugM;
        private Transform currentKids;
        [SerializeField] private StatusEffects _effects;
        private bool slowTheBug;
        private float originalMovementSpeed = 0.5f;


        private void Awake()
        {
            _effects._changedTheColor = false;
        }
        private void Start()
        {
            StartCoroutine(bugUpdate());
        }

        IEnumerator bugUpdate()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                currentKids = gameObject.transform;
                childinParent = GetAllChildren(currentKids);
            }
        }
        
        private void Update()
        {
            if (!_effects._changedTheColor && childinParent != null)
            {
                foreach (GameObject bugG in childinParent)
                {
                    if (bugG != null)
                    {
                        bugM = bugG.GetComponent<BugMovement>();
                        _effects.bugSpeed = originalMovementSpeed;
                    }
                    
                }
            }
            else if (_effects._changedTheColor && childinParent != null)
            {
                foreach (GameObject bugG in childinParent)
                {
                    bugM = bugG.GetComponent<BugMovement>();
                    _effects.bugSpeed = 0.1f;
                }
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
