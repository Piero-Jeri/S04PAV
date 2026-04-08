using Unity.VisualScripting;
using UnityEngine;

public class Enemy : BaseEntity
{
    private void Awake()
    {
        stats = new BaseStats(60, 1, 4, 1, 10);
    }
    void Start()
    {
        //Vector2.Distance(Playerpos, Enemypos);
        
    }

    void Update()
    {

    }


    public override void TakeDamage(BaseEntity damager, Elements element)
    {
        if (stats.Health <= 0)
        {
            Debug.Log("Dejalo, ya está muerto! :'c");
            Die();
            return;
        }

        stats.TakeDamage(damager.Stats.Power);
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Enemigo destruido");
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }*/
}

