using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float speed;
    private ObjectPool<Shoot> poolParent;
    private float releaseTimer = 0.0f;
    private float releaseDelay = 3.0f;
    [SerializeField] Vector3 direction;

    public ObjectPool<Shoot> PoolParent { get => poolParent; set => poolParent = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        releaseTimer += Time.deltaTime;
        transform.Translate(direction.normalized * speed * Time.deltaTime);   


        //Release the bullet to the pool
        if(releaseTimer > releaseDelay)
        {
            poolParent.Release(this);
            releaseTimer = 0;
        }

        if(transform.position.x == 8.20f)
        {
            poolParent.Release(this);
        }

    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        //if the  bullet collisionate with an enemy will be released
        if (this.gameObject.CompareTag("PlayerShoot") && another.gameObject.CompareTag("Enemy"))
        {
            poolParent.Release(this);
        }
    }
}
