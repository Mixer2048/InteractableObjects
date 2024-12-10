using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] public float spawnRate = 2f;
    [SerializeField, Range(1, 20)] public int spawnRange = 15;

    [SerializeField] private List<EnemyProbability> enemyProbabilities = new List<EnemyProbability>();
    private List<EnemyFactory> _enemyFactories = new List<EnemyFactory>();

    EnemyFactory _enemyFactory;

    public void SpawnRandomEnemy()
    {
        _enemyFactory = _enemyFactories[Random.Range(0, _enemyFactories.Count)];
        IEnemy enemy = _enemyFactory.GetEnemy();

        Vector3 direction = new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y);
        direction = direction.normalized * Random.Range(spawnRange, spawnRange);
        Vector3 position = transform.position + direction;

        enemy.positionAndRotation(position, Quaternion.identity);
    }

    private void Start()
    {
        StartCoroutine(RegularSpawn());

        float probabilitySum = 0f;

        foreach (var item in enemyProbabilities)
            probabilitySum += item.probability;

        foreach (var item in enemyProbabilities)
            item.probability = Mathf.Floor((item.probability / probabilitySum) * 100);

        foreach (var item in enemyProbabilities)
            for (int i = 0; i < item.probability; i++)
                _enemyFactories.Add(item.factory);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Tab))
    //        SpawnRandomEnemy();
    //}

    IEnumerator RegularSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            SpawnRandomEnemy();
        }
    }
}
