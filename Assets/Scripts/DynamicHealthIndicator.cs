using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Batty251
{
    public class DynamicHealthIndicator : MonoBehaviour
    {
        [SerializeField] private Sprite[] healthChangingIndicators;
        [SerializeField] private Text bugHealthText;
        [SerializeField] private BugHealth bHealth;
        [SerializeField] private Image healthImageParent;
        private Image healthImage;
        private float bugHealth;

        private void Start()
        {
            bugHealth = Random.Range(bHealth.bugHealthMin, bHealth.bugHealthMax);
            bugHealthText.text = bugHealth.ToString("00") + "%";
            healthImage = healthImageParent;
            healthImage.sprite = healthChangingIndicators[0];
        }


        private void Update()
        {
            switch (healthImage)
            {
                
            }
        }
    }
}
