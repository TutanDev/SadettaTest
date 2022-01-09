using System;
using TutanDev.References;
using UnityEngine;


namespace TutanDev.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public static event Action<GameState> OnGamestateChanged;
        GameState state = GameState.None;

        [SerializeField] Transform EnviromentTransform;
        [SerializeField] GameObject playerPrefab;
        GameObject player;
        [SerializeField] GameObject obstacleSpawnerPrefab;
        GameObject obstacleSpawner;
        [SerializeField]IntReference score ;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ChangeState(GameState.StartScreen);
        }
        public void ChangeState(GameState newState)
        {
            if (state == newState) return;

            state = newState;
            switch (newState)
            {
                case GameState.StartScreen:
                    EndPlaying();
                    break;
                case GameState.Playing:
                    StartPlaying();
                    break;
                case GameState.GameOver:
                    EndPlaying();
                    break;
            }

            OnGamestateChanged?.Invoke(state);
        }

        void StartPlaying()
        {
            score.value = 0;
            player = Instantiate(playerPrefab, EnviromentTransform);
            obstacleSpawner = Instantiate(obstacleSpawnerPrefab, EnviromentTransform);
        }

        void EndPlaying()
        {
            if (player != null)
                Destroy(player);
            if (obstacleSpawner != null)
                Destroy(obstacleSpawner);
        }

        public void AddScore(int add)
        {
            score.value += add;
        }
    }

    public enum GameState
    {
        None,
        StartScreen,
        Playing,
        GameOver
    }
}