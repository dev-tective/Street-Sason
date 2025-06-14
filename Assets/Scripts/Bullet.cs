using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerScore ownerScore;
    private AudioSource boingAudio;
    
    private void Start()
    {
        boingAudio = GetComponent<AudioSource>();
        boingAudio.Play();  
        Destroy(gameObject, 8f);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    public void Fire(float v)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * (v * 2), ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ownerScore != null)
        {
            ownerScore.AddScore();
        }
        
        Destroy(gameObject);
    }
    
    public void SetOwner(PlayerScore owner)
    {
        ownerScore = owner;
    }
}