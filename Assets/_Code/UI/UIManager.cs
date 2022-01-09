using TutanDev.Core;
using UnityEngine;

namespace TutanDev.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Transform Canvases;
        [SerializeField] GameObject startScreenPrefab;
        StartScreen startScreen;
        [SerializeField] GameObject gameOverPrefab;
        GameOver gameOver;
        [SerializeField] GameObject scoreCountPrefab;
        ScoreCount scoreCount;

        private void Start()
        {
            startScreen = Instantiate(startScreenPrefab, Canvases).GetComponent<StartScreen>();
            startScreen.gameObject.SetActive(false);

            gameOver = Instantiate(gameOverPrefab, Canvases).GetComponent<GameOver>();
            gameOver.gameObject.SetActive(false);

            scoreCount = Instantiate(scoreCountPrefab, Canvases).GetComponent<ScoreCount>();
            scoreCount.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.OnGamestateChanged += HandleGameStateChanged;
        }

        void HandleGameStateChanged(GameState newState)
        {
            startScreen.gameObject.SetActive(newState == GameState.StartScreen);
            gameOver.gameObject.SetActive(newState == GameState.GameOver);
            scoreCount.gameObject.SetActive(newState == GameState.Playing);
        }
    }
}