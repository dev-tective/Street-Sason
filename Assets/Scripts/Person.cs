using UnityEngine;

public class Person : MonoBehaviour
{
    public float velocity;
    public Respawn respawn;
    
    public void SetVelocity(float v)
    {
        velocity = v;
    }

    public void SetRespawn(Respawn r)
    {
        respawn = r;
    }
}