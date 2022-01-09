using System.Collections;
using UnityEngine;


namespace TutanDev.Core
{
    [RequireComponent(typeof(ObstaclePool))]
    public class ObstacleSpawner : MonoBehaviour
    {
        ObstaclePool pool;
        [SerializeField] float SpawnInterval = 3;
        [SerializeField] float ObstacleSpeed = 1;
        [Range(1,10)]
        [SerializeField] int updateInterval = 10;
        [Range(0.01f, 0.1f)]
        [SerializeField] float updateMultiplier = 0.1f;
        [SerializeField] AnimationCurve[] trayectories;

        float currentTime = 0.0f;
        float timeSinceLastSpawn = 0.0f;

        private void Awake()
        {
            pool = GetComponent<ObstaclePool>();
            StartCoroutine(UpdateDifficulty());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator UpdateDifficulty()
        {
            while (true)
            {
                currentTime += Time.deltaTime;

                if (currentTime> updateInterval)
                {
                    ObstacleSpeed *= (1 + updateMultiplier);
                    SpawnInterval *= (1 - updateMultiplier);
                    currentTime -= updateInterval;
                }

                yield return null;
            }
        }

        private void Update()
        {
            timeSinceLastSpawn -= Time.deltaTime;

            if(timeSinceLastSpawn < 0.0f)
            {
                SpawnObstacle();
                timeSinceLastSpawn += SpawnInterval;
            }
        }

        void SpawnObstacle()
        {
            pool.Spawn(ObstacleSpeed, trayectories[Random.Range(0, trayectories.Length)]);
        }

    }
}