using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    public float spawnTime = 3f;
    public int EnemyspawnCount = 15;
    public GameController GameController;
    private bool lastEnemySpawn=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawn&&FindObjectOfType<EnemyScript>()==null)
        {
            StartCoroutine(GameController.levelComplete());
        }
    }
    IEnumerator EnemySpawner()
    {
        for(int i = 0;i<=EnemyspawnCount;i++)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy();

        }
       lastEnemySpawn=true;
    }
       
    void SpawnEnemy()
    {
        int randomValue= Random.Range(0, Enemy.Length);
        float randomPos = Random.Range(-1,2);
        Instantiate(Enemy[randomValue],new Vector2(randomPos,transform.position.y),Quaternion.identity);
    }
}
