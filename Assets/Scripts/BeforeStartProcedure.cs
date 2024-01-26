using UnityEngine;
namespace Batty251
{
    public class BeforeStartProcedure : MonoBehaviour
    {
        [SerializeField] private StartGameCheck startedYet;
        [SerializeField] private WindowsOpen doNotOpen;


        private void Start()
        {
            startedYet.gameStarted = false;
            doNotOpen.isAWindowOpened = true;
        }

        public void LetsStartIt()
        {
            startedYet.gameStarted = true;
            doNotOpen.isAWindowOpened = false;
        }
    }
}
