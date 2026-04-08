
using UnityEngine;

public class Potions : BaseCollectables
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                stats.AddHealth(Value);
            }

            Destroy(gameObject);
        }

    }
}
