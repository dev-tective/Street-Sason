using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{ 
    public float time = 60f;
    [SerializeField] public TMP_Text textoTiempo;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f) SceneManager.LoadScene("Final");
        TimeText();
    }

    private void TimeText()
    {
        var s = Mathf.CeilToInt(time);
        textoTiempo.text = s.ToString();
    }
}
