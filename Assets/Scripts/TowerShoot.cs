using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private KeyCode keyForce;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject indicator;
    private const float FireRate = 1f; // Ratio de disparo en segundos
    private float nextFireTime;
    private float shootForce;
    private float lerpTime;
    private const float Duration = 1.5f;

    private void Update()
    {
        ExecuteForce();
        ThrowShot();
        FeedbackRate();
    }

    private void ExecuteForce()
    {
        if (!Input.GetKey(keyForce)) return;
        lerpTime += Time.deltaTime / Duration;
        shootForce = Mathf.Lerp(5f, 10f, lerpTime);
    }

    private void ThrowShot()
    {
        if (!Input.GetKeyUp(keyForce)) return;

        // Verifica si ya ha pasado el tiempo suficiente para disparar
        if (Time.time < nextFireTime) return;

        // Crear la bala
        var clone = Instantiate(bullet, transform.position, transform.rotation);
        if (clone.TryGetComponent<Bullet>(out var mover))
        {
            mover.SetOwner(gameObject.GetComponent<PlayerScore>());
            mover.Fire(shootForce);
        }
        
        // Reiniciar fuerza y tiempo
        shootForce = 0f;
        lerpTime = 0f;

        // Actualizar el tiempo del siguiente disparo permitido
        nextFireTime = Time.time + FireRate;
    }

    private void FeedbackRate()
    {
        if (indicator == null) return;
        indicator.SetActive(Time.time >= nextFireTime);
    }
}