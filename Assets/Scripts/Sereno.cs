using UnityEngine;
using UnityEngine.SceneManagement;

public class Sereno : Person
{
    private new Camera camera;
    private bool hasExited; // Para no repetir escena
    private float margin = 1f;

    private void Start()
    {
        camera = Camera.main;
        Invoke(nameof(Destroy), 3.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));

        if (!hasExited)
        {
            CheckOutOfBounds();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) velocity *= -1.3f;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void CheckOutOfBounds()
    {
        float screenHalfWidth = camera.orthographicSize * camera.aspect;
        float rightLimit = camera.transform.position.x + screenHalfWidth + margin;
        float leftLimit = camera.transform.position.x - screenHalfWidth - margin;

        if (transform.position.x > rightLimit)
        {
            hasExited = true;
            SceneManager.LoadScene("FinalMono");
        }
        else if (transform.position.x < leftLimit)
        {
            hasExited = true;
            SceneManager.LoadScene("FinalLlama");
        }
    }
}

