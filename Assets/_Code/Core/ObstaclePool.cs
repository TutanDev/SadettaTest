using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TutanDev.Core
{
    public class ObstaclePool : MonoBehaviour
    {
        [SerializeField] GameObject obatclePrefab;
        [SerializeField] int size = 10;

        Queue<GameObject> pool;

        private void Awake()
        {
            pool = new Queue<GameObject>();

            for (int i = 0; i < size; i++)
            {
                GameObject obstacle = Instantiate(obatclePrefab, this.transform);
                obstacle.SetActive(false);
                pool.Enqueue(obstacle);
            }
        }

        public void Spawn(float speed, AnimationCurve curve)
        {
            GameObject go = pool.Dequeue();
            go.transform.localPosition = Vector3.zero;
            Obstacle obstacle = go.GetComponent<Obstacle>();
            obstacle.Init(speed, curve);
            go.SetActive(true);

            pool.Enqueue(go);
        }
    }
}