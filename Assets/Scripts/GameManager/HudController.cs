using TMPro;
using UnityEngine;

namespace Platformer.GameManager
{
    public class HudController : IHudController
    {
        private readonly TMP_Text _coinText;
        private readonly GameObject _levelCompletePanel;
        private readonly TMP_Text _leveCompletePanelTitle;
        private readonly TMP_Text _levelCompleteCoins;

        public HudController(TMP_Text coinText, GameObject levelCompletePanel, TMP_Text leveCompletePanelTitle,
            TMP_Text levelCompleteCoins)
        {
            _coinText = coinText;
            _levelCompletePanel = levelCompletePanel;
            _leveCompletePanelTitle = leveCompletePanelTitle;
            _levelCompleteCoins = levelCompleteCoins;
        }

        public void SetLevelCompletedHud(int count)
        {
            _levelCompletePanel.SetActive(true);
            _leveCompletePanelTitle.text = "LEVEL COMPLETE";
            _levelCompleteCoins.text = "COINS COLLECTED: " + count;
        }

        public void Update(int count)
        {
            _coinText.text = count.ToString();
        }
    }
}