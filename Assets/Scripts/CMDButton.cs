using UnityEngine;
namespace Batty251
{
    public class CMDButton : MonoBehaviour
    {
        [SerializeField] private GameObject commandWindow;
        [SerializeField] private WindowsOpen isItOpened;

        private void Start()
        {
            commandWindow.SetActive(false);
            isItOpened.isAWindowOpened = false;
        }

        public void OpenWindow()
        {
            if (!isItOpened.isAWindowOpened)
            {
                commandWindow.SetActive(true);
            }
        }
        public void CloseWindow()
        {
            commandWindow.SetActive(false);
            isItOpened.isAWindowOpened = false;
        }
    }
    
    
}
