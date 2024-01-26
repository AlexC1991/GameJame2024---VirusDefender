using System;
using UnityEngine;
namespace Batty251
{
    public class CreditScreenOperation : MonoBehaviour
    {
        [SerializeField] private GameObject creditScreen;


        private void Awake()
        {
            creditScreen.SetActive(false);
        }
        
        public void OpenCreditsWindow()
        {
            creditScreen.SetActive(true);
        }

        public void CloseCreditsWindow()
        {
            creditScreen.SetActive(false);
        }
    }
}
