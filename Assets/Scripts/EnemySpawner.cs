using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //SerializeField] attribute is used to make the private variables accessible within the Unity editor without making them public 
    [SerializeField]
    private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy(prefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(GameObject enemy)
    {
        //instantiate allows for new objects to be spawned in the scene
        //this function will spawn a enemy with a random location
        //quaternion.identity means that the new enemy will not have any rotations
        GameObject newEnemy = Instantiate(enemy, new Vector3(4f, 1f, 0), Quaternion.identity);
        return null;
    }
}
