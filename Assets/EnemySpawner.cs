using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly List<GameObject> _spawnedEnemies = new List<GameObject>();
    [SerializeField] private GameObject _enemyToSpawn;
    private Coroutine _spawnLoop;

    private float _timeBeforeNextSpawn;

    public float Speed { get; set; }

    public void Run()
    {
        _spawnLoop = StartCoroutine(SpawnThings());
        _timeBeforeNextSpawn = Random.Range(1, 3);
    }

    private IEnumerator SpawnThings()
    {
        while (true)
        {
            _timeBeforeNextSpawn -= Time.deltaTime;
            if (_timeBeforeNextSpawn <= 0)
                SpawnEnemy();
            yield return null;
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(_enemyToSpawn);
        enemy.transform.position = transform.position;
        enemy.GetComponent<Rigidbody2D>().velocity = -enemy.transform.right * Speed;
        _spawnedEnemies.Add(enemy);
        _timeBeforeNextSpawn = Random.Range(2, 3);
    }

    public void StopSpawningThings()
    {
        foreach (var enemy in _spawnedEnemies) Destroy(enemy);
        _spawnedEnemies.Clear();
        if (_spawnLoop != null) StopCoroutine(_spawnLoop);
    }
}