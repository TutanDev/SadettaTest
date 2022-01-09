using TutanDev.Core;
using TutanDev.References;
using UnityEngine;
using System.Linq;

namespace TutanDev.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] Transform topScorePanel;
        [SerializeField] IntReference score;
        [SerializeField] TMPro.TextMeshProUGUI scoreText;
        string initialText;
        GameData gameData;


        public void ContinueClick()
        {
            if (gameData.Sessions.Any(x => x.Score < score.value))
            {
                gameData.Sessions[gameData.Sessions.Count() - 1].Score = score.value;
                gameData.Sessions[gameData.Sessions.Count() - 1].Name = topScorePanel.GetComponentInChildren<TMPro.TMP_InputField>().text;
                gameData.Sessions = gameData.Sessions.OrderByDescending(x => x.Score).ToArray();
                SaveSystem.SaveGame(gameData);
            }

            GameManager.Instance.ChangeState(GameState.StartScreen);
        }


        private void Awake()
        {
            initialText = scoreText.text;
        }

        private void OnEnable()
        {
            gameData = SaveSystem.LoadGame();
            scoreText.text = string.Format(initialText, score.value);
            gameData.Sessions = gameData.Sessions.OrderByDescending(x => x.Score).ToArray();
            topScorePanel.gameObject.SetActive(gameData.Sessions.Any(x => x.Score < score.value));
        }
    }
}

