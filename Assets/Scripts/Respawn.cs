using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private bool leftOrRight;
    [SerializeField] private GameObject client;
    [SerializeField] private new Camera camera;
    [SerializeField] private float ubication;

    private void Start()
    {
        Invoke(nameof(RespawnClient), 0.8f);
    }

    public void RespawnClient()
    {
        print("Se creo.");
        Vector2 vectorRespawn = camera.transform.position;
        var extremes = (camera.orthographicSize * 2 * camera.aspect / 2) + 2;
        vectorRespawn.x = leftOrRight ? -extremes : extremes;
        vectorRespawn.y = -((camera.orthographicSize / 2) * (1 - ubication));   

        var clone = Instantiate(client, vectorRespawn, Quaternion.identity);

        if (clone.TryGetComponent<Client>(out var mover))
        {
            var velocity = Random.Range(4f, 7f);
            mover.SetVelocity(leftOrRight ? velocity : -velocity);
            mover.SetRespawn(this);
        }

        leftOrRight = !leftOrRight;
    }
}