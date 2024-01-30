using UnityEngine;
using UnityEngine.UI;
namespace Batty251
{
    public class UpgradeMenu : MonoBehaviour
    {
        [SerializeField] private ClipBoardDisplay moneyToUse;
        [SerializeField] private Text virusSeekerTwoText;
        [SerializeField] private Text virusSeekerThreeText;
        [SerializeField] private Text virusDefenderTwoText;
        [SerializeField] private Text virusDefenderThreeText;
        [SerializeField] private GameObject upgradeMenu;
        [SerializeField] private GameObject virusSeekerOriginal;
        [SerializeField] private GameObject virusSeekerTwo;
        [SerializeField] private GameObject virusSeekerThree;
        [SerializeField] private GameObject virusDefenderOriginal;
        [SerializeField] private GameObject virusDefenderTwo;
        [SerializeField] private GameObject virusDefenderThree;
        [SerializeField] private Text totalAmoundCanSpend;


        private void Awake()
        {
            upgradeMenu.SetActive(false);
            virusSeekerTwoText.text = "400";
            virusSeekerThreeText.text = "1200";
            virusDefenderTwoText.text = "350";
            virusDefenderThreeText.text = "900";
            virusDefenderOriginal.SetActive(true);
            virusDefenderTwo.SetActive(false);
            virusDefenderThree.SetActive(false);
            virusSeekerOriginal.SetActive(true);
            virusSeekerTwo.SetActive(false);
            virusSeekerThree.SetActive(false);
            totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
        }


        public void OpenUpgradeMenu()
        {
            upgradeMenu.SetActive(true);
            totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
        }

        public void BuyingVirusSeeker2()
        {
            if (moneyToUse._moneyTotal >= 400 && virusSeekerTwoText.text != "Owned")
            {
                virusSeekerTwoText.text = "Owned";
                moneyToUse._moneyTotal -= 400;
                totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
            }
            else if (virusSeekerOriginal.activeSelf && virusSeekerTwoText.text == "Owned")
            {
                virusSeekerOriginal.SetActive(false);
                virusSeekerTwo.SetActive(true);
            }
            else if (virusSeekerThree.activeSelf && virusSeekerTwoText.text == "Owned")
            {
                virusSeekerThree.SetActive(false);
                virusSeekerTwo.SetActive(true);
            }
        }
        
        public void BuyingVirusSeeker3()
        {
            if (moneyToUse._moneyTotal >= 1200 && virusSeekerThreeText.text != "Owned")
            {
                virusSeekerThreeText.text = "Owned";
                moneyToUse._moneyTotal -= 1200;
                totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
            }
            else if (virusSeekerOriginal.activeSelf && virusSeekerThreeText.text == "Owned")
            {
                virusSeekerOriginal.SetActive(false);
                virusSeekerThree.SetActive(true);
            }
            else if (virusSeekerTwo.activeSelf && virusSeekerThreeText.text == "Owned")
            {
                virusSeekerTwo.SetActive(false);
                virusSeekerThree.SetActive(true);
            }
        }

        public void OriginalVirusSeekerToggle()
        {
            if (virusSeekerTwo.activeSelf && !virusSeekerOriginal.activeSelf)
            {
                virusSeekerTwo.SetActive(false);
                virusSeekerOriginal.SetActive(true);
            }
            else if (virusSeekerThree.activeSelf && !virusSeekerOriginal.activeSelf)
            {
                virusSeekerThree.SetActive(false);
                virusSeekerOriginal.SetActive(true);
            }
        }
        
        public void BuyingVirusDefender2()
        {
            if (moneyToUse._moneyTotal >= 350 && virusDefenderTwoText.text != "Owned")
            {
                virusDefenderTwoText.text = "Owned";
                moneyToUse._moneyTotal -= 350;
                totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
            }
            else if (virusDefenderOriginal.activeSelf && virusDefenderTwoText.text == "Owned")
            {
                virusDefenderOriginal.SetActive(false);
                virusDefenderTwo.SetActive(true);
            }
            else if (virusDefenderThree.activeSelf && virusDefenderTwoText.text == "Owned")
            {
                virusDefenderThree.SetActive(false);
                virusDefenderTwo.SetActive(true);
            }
        }
        
        public void BuyingVirusDefender3()
        {
            if (moneyToUse._moneyTotal >= 900 && virusDefenderThreeText.text != "Owned")
            {
                virusDefenderThreeText.text = "Owned";
                moneyToUse._moneyTotal -= 900;
                totalAmoundCanSpend.text = "Available Balance: $" + moneyToUse._moneyTotal.ToString("00");
            }
            else if (virusDefenderOriginal.activeSelf && virusDefenderThreeText.text == "Owned")
            {
                virusDefenderOriginal.SetActive(false);
                virusDefenderThree.SetActive(true);
            }
            else if (virusDefenderTwo.activeSelf && virusDefenderThreeText.text == "Owned")
            {
                virusDefenderTwo.SetActive(false);
                virusDefenderThree.SetActive(true);
            }
        }

        public void OriginalVirusDefenderToggle()
        {
            if (virusDefenderTwo.activeSelf && !virusDefenderOriginal.activeSelf)
            {
                virusDefenderTwo.SetActive(false);
                virusDefenderOriginal.SetActive(true);
            }
            else if (virusDefenderThree.activeSelf && !virusDefenderOriginal.activeSelf)
            {
                virusDefenderThree.SetActive(false);
                virusDefenderOriginal.SetActive(true);
            }
        }

        public void CloseUpgeadeMenu()
        {
            upgradeMenu.SetActive(false);
        }
    }
}
