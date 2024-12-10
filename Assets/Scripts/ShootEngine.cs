using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShootEngine : MonoBehaviour
{
    private ObjectPool<Shoot> shootPool;
    [SerializeField]  private Shoot bullet;
    [SerializeField]  private GameObject bulletSpawn;


    public ObjectPool<Shoot> ShootPool { get => shootPool; set => shootPool = value; }

    private void Awake()
    {
        shootPool = new ObjectPool<Shoot>(createBullet, getBullet, releaseBullet, destroyBullet);
    }

    private Shoot createBullet()
    {
        Shoot shoot = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
        shoot.PoolParent = shootPool;
        return shoot;

    }

    private void getBullet(Shoot shoot)
    {
        shoot.transform.position = transform.position;
        shoot.gameObject.SetActive(true);
    }

    private void releaseBullet(Shoot shoot)
    {
        Debug.Log("aaaaa");
        shoot.gameObject.SetActive(false);
    }

    private void destroyBullet(Shoot shoot)
    {

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
