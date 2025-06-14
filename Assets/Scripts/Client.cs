using UnityEngine;

public class Client : MonoBehaviour
{
    private float velocity;

    public void SetVelocity(float v)
    {
        velocity = v;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            print("Cliente satisfecho");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}