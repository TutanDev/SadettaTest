using UnityEngine;

namespace TutanDev.Core
{
    public class Obstacle : MonoBehaviour
    {
        const int PlayerLayer = 6;
        const float rightScreenLimit = 5.7f;
        const float topScreenLimit = 1.7f;


        [SerializeField] AnimationCurve curve;
        float speed = 1;

        Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }

        private void Update()
        {
            Vector3 targetPosition = myTransform.position + Vector3.left * (speed * Time.deltaTime);
            if (myTransform.position.x <= rightScreenLimit && myTransform.position.x >= -rightScreenLimit) // In screen
            {
                float proggres = Mathf.InverseLerp(-rightScreenLimit, rightScreenLimit, myTransform.position.x);
                float yPos = Mathf.Clamp01(curve.Evaluate(proggres)); // value from 0-1
                yPos = (yPos - 0.5f) * topScreenLimit * 2; // value in screen reange
                targetPosition.y = yPos; 
            }
            transform.position = Vector3.Lerp(myTransform.position, targetPosition, 0.8f);
        }


        public void Init(float speed, AnimationCurve curve)
        {
            this.speed = speed;
            this.curve = curve;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == PlayerLayer)
            {
                GameManager.Instance.ChangeState(GameState.GameOver);
            }
        }
    }
}