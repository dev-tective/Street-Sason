using UnityEngine;

public class Client : Person
{
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        if (sound == null)
        {
            Debug.LogError("No AudioSource assigned: agrega sonido OE BASURA");
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            velocity *= 5;
            sound.Play();
            //falta agregar un sonido
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