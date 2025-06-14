using UnityEngine;

public class Client : Person
{
    private float velocity;
    private Respawn respawn;
    private AudioSource fuimmSound;

    private void Start()
    {
        fuimmSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            velocity *= 10;
            fuimmSound.Play();
        }
    }

    private void OnBecameInvisible()
    {
        Invoke(nameof(DestroyAndRespawn), 0.5f);
    }

    private void DestroyAndRespawn()
    {
        Destroy(gameObject);
        respawn.RespawnClient();
    }
}