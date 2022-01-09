using TutanDev.References;
using UnityEngine;

namespace TutanDev.UI
{
    public class ScoreCount : MonoBehaviour
    {
        [SerializeField] IntReference score;
        [SerializeField] TMPro.TextMeshProUGUI scoreText;

        private void Update()
        {
            if (string.Compare(score.value.ToString(), scoreText.text) != 0)
            {
                scoreText.text = score.value.ToString();
            }
        }
    }
}