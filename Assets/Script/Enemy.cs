using UnityEngine;

public class Enemy : BaseEntity
{
    private void Awake()
    {
        stats = new BaseStats(60, 1, 4, 1, 10);
    }
    void Start()
    {

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


        stats.TakeDamage(stats.Power);
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Enemigo destruido");
    }
}

