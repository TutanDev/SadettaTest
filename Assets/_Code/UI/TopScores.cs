using TutanDev.SaveSystem;
using UnityEngine;

namespace TutanDev.UI
{
    public class TopScores : MonoBehaviour
    {
        GameObject scorePrefab;

        public void Init(GameData data)
        {
            scorePrefab = transform.GetChild(0).gameObject;
            scorePrefab.SetActive(false);

            for (int i = 1; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (var session in data.Sessions)
            {
                var go = Instantiate(scorePrefab, transform);
                go.SetActive(true);
                go.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"{session.Name} score: {session.Score}";
            }
        }
    }
}