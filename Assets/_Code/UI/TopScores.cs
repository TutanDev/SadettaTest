using TutanDev.SaveSystem;
using UnityEngine;

namespace TutanDev.UI
{
    public class TopScores : MonoBehaviour
    {
        GameObject scorePrefab;

        private void Awake()
        {
            scorePrefab = transform.GetChild(0).gameObject;
            scorePrefab.SetActive(false);
        }

        public void Init(GameData data)
        {
            foreach (var session in data.Sessions)
            {
                var go = Instantiate(scorePrefab, transform);
                go.SetActive(true);
                go.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"{session.Name} score: {session.Score}";
            }
        }
    }
}