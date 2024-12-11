using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ZigZagEnemy : Enemy
{
    // Start is called before the first frame update

    private float posY = 1.0f;

    private ObjectPool<ZigZagEnemy> poolParent;

    public ObjectPool<ZigZagEnemy> PoolParent1 { get => poolParent; set => poolParent = value; }

    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x > 8.20f)
        {
            transform.Translate(new Vector3(-1.0f, 0.0f, 0.0f).normalized * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(-1.0f, posY, 0.0f).normalized * speed * Time.deltaTime);

            if(transform.position.y >= 4.60f)
            {
                transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f).normalized * speed * Time.deltaTime);
                posY = -1.0f;
            }

            if(transform.position.y <= -4.60f)
            {
                transform.Translate(new Vector3(-5.0f, 0.0f, 0.0f).normalized * speed * Time.deltaTime);
                posY = 1.0f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.gameObject.CompareTag("PlayerShoot"))
        {
            lifes -= 1;
            if (lifes == 0)
            {
                poolParent.Release(this);
            }

        }
    }
}
