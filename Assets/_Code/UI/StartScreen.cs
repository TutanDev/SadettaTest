using TutanDev.Core;
using TutanDev.References;
using UnityEditor;
using UnityEngine;

namespace TutanDev.UI
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] BoolReference exitReference;
        TopScores topScores;

        public void StartClick()
        {
            GameManager.Instance.ChangeState(GameState.Playing);
        }

        private void Awake()
        {
            topScores = GetComponentInChildren<TopScores>();
        }

        private void OnEnable()
        {
            topScores.Init(SaveSystem.SaveSystem.LoadGame());
        }

        private void Update()
        {
            if (!exitReference.value) return;

            if(Application.platform == RuntimePlatform.WindowsEditor)
            {
                EditorApplication.ExitPlaymode();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}