using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{ 
    public float time = 60f;
    [SerializeField] public TMP_Text textoTiempo;
    [SerializeField] public TMP_Text[] textoScore;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            var player1 = int.Parse(textoScore[0].text);
            var player2 = int.Parse(textoScore[1].text);
            SceneManager.LoadScene(player1 < player2 ? "FinalLlama" : "FinalMono");
        }
        TimeText();
    }

    private void TimeText()
    {
        var s = Mathf.CeilToInt(time);
        textoTiempo.text = s.ToString();
    }
}
