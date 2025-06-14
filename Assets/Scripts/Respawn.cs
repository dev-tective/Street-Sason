using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private bool leftOrRight;
    [SerializeField] private GameObject client;
    [SerializeField] private new Camera camera;
    [SerializeField] private float ubication;
    [SerializeField] private string typeRespawn;

    private void Start()
    {
        if (typeRespawn == "sereno")
        {
            Invoke(nameof(RespawnClient), 10f); 
            return;
        }
        Invoke(nameof(RespawnClient), 0.8f);
    }

    public void RespawnClient()
    {
        print("Se creo.");
        Vector2 vectorRespawn = camera.transform.position;

        if (typeRespawn == "sereno")
        {
            // Centro inferior de la pantalla
            vectorRespawn.x = 0f;
            vectorRespawn.y = -camera.orthographicSize + 1f; // Ajuste para que esté visible
        }
        else
        {
            // Lateral izquierdo o derecho
            var extremes = (camera.orthographicSize * 2 * camera.aspect / 2) + 2;
            vectorRespawn.x = leftOrRight ? -extremes : extremes;
            vectorRespawn.y = -((camera.orthographicSize / 2) * (1 - ubication));
        }

        var clone = Instantiate(client, vectorRespawn, Quaternion.identity);

        if (clone.TryGetComponent<Person>(out var mover))
        {
            var velocity = Random.Range(4f, 7f);
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
}