using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    float timer = 0f;
    [SerializeField]
    float spawnRate;
    [SerializeField]
    int maxSpawned;

    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies.RemoveAll(obj => obj == null);

        timer = Mathf.Max(timer - Time.deltaTime, 0f);
        if (enemies.Count < maxSpawned && timer == 0f)
        {
            timer = spawnRate;
            enemies.Add(Instantiate(enemy, transform));
        }
    }
}
