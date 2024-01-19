using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class VirusDefenderScript : MonoBehaviour
    {
        [SerializeField] private GameObject scanningWindow;
        [SerializeField] private GameObject[] percentageIndicators;
        [SerializeField] private GameObject percentageText;
        [SerializeField] private Text percentageIndicatorText;
        [SerializeField] private GameObject virusWallDefender;
        [SerializeField] private GameObject backgroundColor;
        [SerializeField] private StatusEffects currentTile;
        private GameObject[] childObjects;
        private Transform childrenInParent;

        private void Awake()
        {
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
            scanningWindow.SetActive(false);
            virusWallDefender.SetActive(false);
        }

        private void Start()
        {
            foreach (GameObject indicators in percentageIndicators)
            {
                indicators.SetActive(false);
            }

            StartCoroutine(childChecker());
        }

        IEnumerator childChecker()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                childrenInParent = backgroundColor.transform;
                childObjects = GetAllChildren(childrenInParent);
                if (!currentTile._changedTheColor && childObjects != null)
                {
                    foreach (GameObject g in childObjects)
                    {
                        currentTile.originalTileColorEffect = g.GetComponent<SpriteRenderer>().color;
                    }
                }
            }
        }
        
        public void OnClickedStart()
        {
            StartCoroutine(PercentageCalculateStart());
        }

        IEnumerator PercentageCalculateStart()
        {
            scanningWindow.SetActive(true);
            percentageText.SetActive(true);
            percentageIndicatorText.text = "1%";
            percentageIndicators[0].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "5%";
            percentageIndicators[1].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "8%";
            percentageIndicators[2].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "12%";
            percentageIndicators[3].SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            percentageIndicatorText.text = "20%";
            percentageIndicators[4].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "29%";
            percentageIndicators[5].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "34%";
            percentageIndicators[6].SetActive(true);
            yield return new WaitForSecondsRealtime(0.2f);
            percentageIndicatorText.text = "40%";
            percentageIndicators[7].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "52%";
            percentageIndicators[8].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "59%";
            percentageIndicators[9].SetActive(true);
            yield return new WaitForSecondsRealtime(0.6f);
            percentageIndicatorText.text = "65%";
            percentageIndicators[10].SetActive(true);
            yield return new WaitForSecondsRealtime(0.4f);
            percentageIndicatorText.text = "69%";
            percentageIndicators[11].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "74%";
            percentageIndicators[12].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "79%";
            percentageIndicators[13].SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
            percentageIndicatorText.text = "85%";
            percentageIndicators[14].SetActive(true);
            yield return new WaitForSecondsRealtime(0.1f);
            percentageIndicatorText.text = "92%";
            percentageIndicators[15].SetActive(true);
            yield return new WaitForSecondsRealtime(0.7f);
            percentageIndicatorText.text = "96%";
            percentageIndicators[16].SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            percentageIndicatorText.text = "98%";
            percentageIndicators[17].SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
            percentageIndicatorText.text = "99%";
            percentageIndicators[18].SetActive(true);
            yield return new WaitForSecondsRealtime(1.5f);
            scanningWindow.SetActive(false);
            percentageText.SetActive(false);
            for (int i = 0; i < percentageIndicators.Length; i++)
            {
                percentageIndicators[i].SetActive(false);
            }
            childrenInParent = backgroundColor.transform;
            childObjects = GetAllChildren(childrenInParent);
            currentTile._changedTheColor = true;
            foreach (var g in childObjects)
            {
                g.GetComponent<SpriteRenderer>().color = currentTile.tileSlowEffectColor;
            }
            foreach (GameObject indicators in percentageIndicators)
            {
                indicators.SetActive(false);
            }
            yield return new WaitForSecondsRealtime(3f);
            childrenInParent = backgroundColor.transform;
            childObjects = GetAllChildren(childrenInParent);
            foreach (var g in childObjects)
            {
                g.GetComponent<SpriteRenderer>().color = currentTile.originalTileColorEffect;
            }
            currentTile._changedTheColor = false;
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
