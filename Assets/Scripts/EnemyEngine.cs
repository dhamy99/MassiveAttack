using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyEngine : MonoBehaviour
{

    private ObjectPool<Enemy> enemyPool;
    [SerializeField] private Enemy enemy;
    [SerializeField] GameObject enemySpawn;

    public ObjectPool<Enemy> EnemyPool { get => enemyPool; set => enemyPool = value; }

    private void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(createEnemy, getEnemy, releaseEnemy, destroyEnemy);

    }
    private Enemy createEnemy()
    {
        Enemy enemyGen = Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
        enemyGen.PoolParent = enemyPool;
        return enemyGen;
    }
    private void getEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
