using UnityEngine;
using UnityEngine.UI;

namespace Batty251
{
    public class SettingsMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject backGroundImage;
        [SerializeField] private Sprite[] listOfBackGroundImages;
        [SerializeField] private SettingsMenuContainer startingBackground;
        public void Start()
        {
            settingsMenu.SetActive(false);
            backGroundImage.GetComponent<SpriteRenderer>().sprite =
                listOfBackGroundImages[startingBackground.backgroundSelected];
        }

        public void OpenSettings()
        {
            settingsMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public void CloseSettings()
        {
            settingsMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
