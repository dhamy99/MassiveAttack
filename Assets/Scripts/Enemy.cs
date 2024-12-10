using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float shootDelay;
    private ObjectPool<Enemy> poolParent;

    public ObjectPool<Enemy> PoolParent { get => poolParent; set => poolParent = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("disparo");
        Move();
    }

    void Move()
    {
        transform.Translate(new Vector3(-1.0f , 0.0f , 0.0f).normalized * speed * Time.deltaTime);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Debug.Log("disparo");
            GetComponent<ShootEngine>().ShootPool.Get();
            yield return new WaitForSeconds(shootDelay);
        }      
        
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.gameObject.CompareTag("PlayerShoot"))
        {
            poolParent.Release(this);
        }
    }
}
