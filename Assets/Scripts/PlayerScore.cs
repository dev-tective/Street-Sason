using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private TMP_Text scoreText;
    private int score;

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
