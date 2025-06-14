using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start()
    {
        PositioningPlayers();
    }

    private void PositioningPlayers()
    {
        var cam = Camera.main;
        // Medidas del viewport
        if (cam == null) return;
        var camHeight = cam.orthographicSize * 2f;
        var camWidth = camHeight * cam.aspect;

        // Margen para no pegarlos al borde exacto
        const float margin = 1.5f;

        // Posiciones base
        var camPos = cam.transform.position;

        var pos1 = new Vector3(
            camPos.x - camWidth / 2 + margin,
            camPos.y - camHeight / 2 + margin,
            0f);

        var pos2 = new Vector3(
            camPos.x + camWidth / 2 - margin,
            camPos.y - camHeight / 2 + margin,
            0f);

        if (player1 != null) player1.transform.position = pos1;
        if (player2 != null) player2.transform.position = pos2;
    }
}
