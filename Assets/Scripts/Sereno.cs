using UnityEngine;

public class Sereno : Person
{
    private void Start()
    {
        Invoke(nameof(DestroyAndRespawn), 10f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            velocity *= -2;
        }
    }

    private void DestroyAndRespawn()
    {
        Destroy(gameObject);
        respawn.RespawnClient();
    }
}
