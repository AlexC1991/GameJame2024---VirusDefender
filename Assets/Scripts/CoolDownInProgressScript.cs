using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class CoolDownInProgressScript : MonoBehaviour
    {
        private Sprite originalSprite;
        [SerializeField] private Sprite[] countDownSprites;
        private float alphaColor;
        private void Start()
        {
            alphaColor = GetComponentInChildren<Text>().color.a;
            originalSprite = gameObject.GetComponent<Image>().sprite;
        }

        public bool StartCoolDown()
        {
            StartCoroutine(CoolingDownProcess());
            return false;
        }

        IEnumerator CoolingDownProcess()
        {
            alphaColor = 0.5f;
            gameObject.GetComponent<Image>().sprite = countDownSprites[0];
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<Image>().sprite = countDownSprites[1];
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<Image>().sprite = countDownSprites[2];
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<Image>().sprite = countDownSprites[3];
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<Image>().sprite = countDownSprites[4];
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<Image>().sprite = originalSprite;
            alphaColor = 1;
        }
    }
}
