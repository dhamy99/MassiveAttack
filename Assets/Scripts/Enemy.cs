using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float shootDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
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
            GetComponent<ShootEngine>().ShootPool.Get();
            yield return new WaitForSeconds(shootDelay);
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.gameObject.CompareTag("PlayerShoot"))
        {
            Destroy(another.gameObject);
            Destroy(this.gameObject);
        }
    }
}
