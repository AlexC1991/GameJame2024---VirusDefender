using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class ComputerHealthStatus : MonoBehaviour
    {
        [SerializeField] private Text computerHealthText;
        private GameObject[] tileHealthChildren;
        private int healthTotalNumber;
        private float checkInterval = 2f;
        private float healthPercentage;


        private void Start()
        {
            StartCoroutine(CountDownToCheck());
            tileHealthChildren = GetAllChildren(gameObject.transform);
        }


        IEnumerator CountDownToCheck()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                tileHealthChildren = GetAllChildren(gameObject.transform);
                CalculateHealthPercentage();
            }
        }
        

        private void CalculateHealthPercentage()
        {
            int totalTiles = tileHealthChildren.Length;
            
            if (totalTiles > 0)
            {
                int remainingTiles = GetRemainingTileCount();
                
                healthPercentage = (float)remainingTiles / totalTiles * 100f;
                computerHealthText.text = "Pc Health: \n" + "    " + healthPercentage.ToString("00") + "%";
            }
            else
            {
                Debug.Log("No tiles found.");
                tileHealthChildren = GetAllChildren(gameObject.transform);
            }
        }

        private int GetRemainingTileCount()
        {
            int remainingTiles = 0;

            foreach (GameObject tile in tileHealthChildren)
            {
                SpriteRenderer tileRenderer = tile.GetComponent<SpriteRenderer>();
                
                if (tileRenderer != null && tileRenderer.sortingOrder == -1)
                {
                    remainingTiles++;
                }
            }

            return remainingTiles;
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
