using UnityEngine;
namespace Batty251
{
    public class CMDButton : MonoBehaviour
    {
        [SerializeField] private GameObject commandWindow;
        [SerializeField] private WindowsOpen isItOpened;
        [SerializeField] private SettingsMenuContainer clickChecker;
        private int clickingAmount;

        private void Start()
        {
            commandWindow.SetActive(false);
            isItOpened.isAWindowOpened = false;
        }

        public void OpenWindow()
        {
            clickingAmount += 1;
            
            if (!isItOpened.isAWindowOpened && clickingAmount >= clickChecker.amountOfClicks)
            {
                commandWindow.SetActive(true);
                clickingAmount = 0;
            }
        }
        public void CloseWindow()
        {
            commandWindow.SetActive(false);
            isItOpened.isAWindowOpened = false;
            clickingAmount = 0;
        }
    }
    
    
}
