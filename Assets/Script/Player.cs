
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    public float range;

    public CircleCollider2D coll;

    public List<GameObject> Enemys = new();

    private void Awake()
    {
        stats = new BaseStats(10, 10, 5, 1, 20);//->A
        print(stats.Power);

        coll = GetComponent<CircleCollider2D>();
        coll.radius = range;
    }
    void Start()
    {

        InvokeRepeating("AutoAttackEnemies", 1f, 1f);
    }

    void Update()
    {

    }
    public void AutoAttackEnemies()
    {
        print("ATAQUE!");


        foreach (GameObject enemy in Enemys)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);

            if (distance <= range && enemy.GetComponent<Enemy>() != null)
                enemy.GetComponent<Enemy>().TakeDamage(this, Element);
        }
        
    }

    private void OnDestroy()
    {
        Debug.Log("oh no me cancelaron");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        Enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemys.Remove(collision.gameObject);
    }

    public override void TakeDamage(BaseEntity damager, Elements element)
    {
        if(CompareTag("Enemy"))
        {
            Debug.Log(damager.Element);

            int damage = damager.Stats.Power;

            switch (damager.Element)
            {
                case Elements.None:
                    //damage = damage;
                    break;
                case Elements.Fire:
                    damage *= 2;
                    break;
                case Elements.Water:
                    damage /= 2;
                    break;
                case Elements.Earth:
                    damage *= 3;
                    break;
                case Elements.Air:
                    damage = 0;
                    break;
                default:
                    break;
            }

            stats.TakeDamage(damage); 
        }
    }


}
    
