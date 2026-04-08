using UnityEngine;

public class XP : BaseCollectables
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                stats.AddXP(Value);
            }

            Destroy(gameObject);
        }

    }
}
