using UnityEngine;

namespace TutanDev.Core
{
    public class Limit : MonoBehaviour
    {
        const int PlayerLayer = 6;
        const int ObstacleLayer = 7;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == PlayerLayer)
            {
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
            else if (other.gameObject.layer == ObstacleLayer)
            {
                GameManager.Instance.AddScore(1);
            }
        }
    }
}
