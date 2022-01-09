using UnityEngine;

namespace TutanDev.UI
{
    public class StartScreen : MonoBehaviour
    {
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
    }
}