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
            // EventManager.Start.Invoke
        }

        private void Start()
        {
            topScores = GetComponentInChildren<TopScores>();
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