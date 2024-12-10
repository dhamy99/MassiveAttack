using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private TextMeshProUGUI waveText;

    private ObjectPool<Enemy> enemyPool;

    public ObjectPool<Enemy> EnemyPool { get => enemyPool; set => enemyPool = value; }

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(createEnemy, getEnemy, releaseEnemy, destroyEnemy);

    }

    private Enemy createEnemy()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, UnityEngine.Random.Range(-4.60f, 4.60f), 0);

        Enemy enemyGen = Instantiate(enemy, spawnPoint, Quaternion.identity);
        enemyGen.PoolParent = enemyPool;
        return enemyGen;
    }
    private void getEnemy(Enemy enemy)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, UnityEngine.Random.Range(-4.60f, 4.60f), 0);
        enemy.transform.position = spawnPoint;
        enemy.gameObject.SetActive(true);
    }
    private void releaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }


    private void destroyEnemy(Enemy enemy)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int n = 0; n < 5; n++)
        {   
            for (int i = 0; i < 3; i++)
            {
                waveText.text = "Level" + "" + (n + 1)  + "-" + "Wave" + "" + (i + 1);
                yield return new WaitForSeconds(2.0f);
                waveText.text = "";
                for (int j = 0; j < 10; j++)
                {
                    enemyPool.Get();
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(3f);
        }
        
    }
}
