using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float timeRespawn = 2f;
    [SerializeField] private bool leftOrRight;
    [SerializeField] private GameObject client;
    [SerializeField] private new Camera camera;
    [SerializeField] private float ubication;
    
    private void Start()
    {
        StartCoroutine(RespawnCycle());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator RespawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRespawn);

            if (!client) continue;
            //Obtengo la medida de la camara y posiciono el cliente
            Vector2 vectorRespawn = camera.transform.position;
            var extremes = (camera.orthographicSize * 2 * camera.aspect / 2) + 2;
            vectorRespawn.x = leftOrRight ? -extremes : extremes;
            vectorRespawn.y = -((camera.orthographicSize / 2) * (1 - ubication));   

            var clone = Instantiate(client, vectorRespawn, Quaternion.identity);

            if (clone.TryGetComponent<Client>(out var mover))
            {
                mover.SetVelocity(leftOrRight ? velocity : -velocity);
            }

            leftOrRight = !leftOrRight;
        }
        // ReSharper disable once IteratorNeverReturns
    }
}