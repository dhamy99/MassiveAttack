using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootDelay;
    private float timer = 0.5f;
    private int life = 100;
    private int damage = 1;

    [SerializeField] private HealthBar healthBar;

    public int Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.initializeHealthBar(life);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        shoot();
    }

    void move()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(inputH, inputV).normalized * speed * Time.deltaTime);

        //Limiting the movement
        float xClamp = Mathf.Clamp(transform.position.x, -8.20f, 8.20f);
        float yClamp = Mathf.Clamp(transform.position.y, -4.60f, 4.60f);
        transform.position = new Vector3(xClamp, yClamp, 0);
    }

    void shoot()
    {
        timer += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > shootDelay)
        {
            //Obtaining from shoot pool
            GetComponent<ShootEngine>().ShootPool.Get();
            timer=0;
        }
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.gameObject.CompareTag("EnemyShoot") || another.gameObject.CompareTag("Enemy"))
        {
            life -= 20;
            healthBar.UpdateHealthValue(life);
            Destroy(another.gameObject);
            if(life <= 0)
            {
                Destroy(this.gameObject);  
            }
        }
    }
}
