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
                print("Player death");
            }
            else if (other.gameObject.layer == ObstacleLayer)
            {
                print("Score + 1");
            }
        }
    }
}
