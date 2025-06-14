using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private bool leftOrRight;
    [SerializeField] private GameObject[] client;
    [SerializeField] private new Camera camera;
    [SerializeField] private float ubication;
    [SerializeField] private string typeRespawn;

    private void Start()
    {
        if (typeRespawn == "sereno")
        {
            StartCoroutine(DestroyAndRespawnSereno());
            return;
        }
        Invoke(nameof(RespawnClient), 0.8f);
    }

    public void RespawnClient()
    {
        print("Se creo.");
        Vector2 vectorRespawn = camera.transform.position;
        
        var extremes = (camera.orthographicSize * 2 * camera.aspect / 2) + 2;
        vectorRespawn.x = leftOrRight ? -extremes : extremes;
        vectorRespawn.y = -((camera.orthographicSize / 2) * (1 - ubication));

        var clone = Instantiate(client[Random.Range(0, client.Length)], vectorRespawn, Quaternion.identity);

        if (clone.TryGetComponent<Person>(out var mover))
        {
            var velocity = Random.Range(1f, 4f);
            mover.SetVelocity(leftOrRight ? velocity : -velocity);

            // Voltear sprite si viene desde la izquierda
            if (leftOrRight)
            {
                mover.gameObject.transform.localScale = 
                    new Vector2(-mover.gameObject.transform.localScale.x, mover.gameObject.transform.localScale.y);
            }

            mover.SetRespawn(this);
        }

        leftOrRight = !leftOrRight;
    }

    private IEnumerator DestroyAndRespawnSereno()
    {
        yield return new WaitForSeconds(10f);
        Vector2 vectorRespawn = camera.transform.position;
        vectorRespawn.x = 0f;
        vectorRespawn.y = -camera.orthographicSize + 1.5f;
        var clone = Instantiate(client[0],vectorRespawn, Quaternion.identity);
        if (clone.TryGetComponent<Person>(out var mover))
        {
            var velocity = 3f;
            mover.SetVelocity(leftOrRight ? velocity : -velocity);

            // Voltear sprite si viene desde la izquierda
            if (leftOrRight)
            {
                mover.gameObject.transform.localScale = 
                    new Vector2(-mover.gameObject.transform.localScale.x, mover.gameObject.transform.localScale.y);
            }
        }

        leftOrRight = !leftOrRight;
        StartCoroutine(DestroyAndRespawnSereno());
    }
}