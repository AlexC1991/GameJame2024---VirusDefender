using System.Collections;
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
        [SerializeField] private MusicScriptableObject bugDeathSound;
        private Image healthImage;
        private float initialBugHealth;
        private float currentBugHealth;
        private int healthIndicatorNumber;

        private void Start()
        {
            initialBugHealth = Random.Range(bHealth.bugHealthMin, bHealth.bugHealthMax);
            currentBugHealth = initialBugHealth;
            healthImage = healthImageParent;
            healthImage.sprite = healthChangingIndicators[0];
            healthIndicatorNumber = 1;
            HealthChange();
        }

        private void HealthChange()
        {
            float percentage = (initialBugHealth > 0) ? (currentBugHealth / initialBugHealth) * 100 : 100;
            bugHealthText.text = Mathf.RoundToInt(percentage) + "%";
            
            switch (healthIndicatorNumber)
            {
                case 1:
                    healthImage.sprite = healthChangingIndicators[0];
                    break;
                case 2:
                    healthImage.sprite = healthChangingIndicators[1];
                    break;
                case 3:
                    healthImage.sprite = healthChangingIndicators[2];
                    break;
                case 4:
                    healthImage.sprite = healthChangingIndicators[3];
                    break;
                case 5:
                    healthImage.sprite = healthChangingIndicators[4];
                    break;
                case 6:
                    healthImage.sprite = healthChangingIndicators[5];
                    break;
                case 7:
                    healthImage.sprite = healthChangingIndicators[6];
                    break;
            }
        }
        
        public void TakeDamage(float damageAmount)
        {
            currentBugHealth -= damageAmount;

            if (currentBugHealth <= 0)
            {
                currentBugHealth = 0;
            }
            HealthChange();

            if (currentBugHealth <= 0)
            {
                StartCoroutine(DeathOfBug());
            }
        }

        IEnumerator DeathOfBug()
        {
            gameObject.GetComponent<ParticleSystem>().Play();
            bugDeathSound.sfxSoundFiles[0].PlayAudio();
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
    }
}
