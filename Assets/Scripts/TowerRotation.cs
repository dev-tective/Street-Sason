using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    // ReSharper disable once InconsistentNaming
    [SerializeField] private KeyCode keyUP;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    private Transform towerTransform;
    private float angleToShooting;
  
    private void Start()
    {
        towerTransform = transform;
    }

    private void Update()
    {
        angleToShooting = Mathf.Clamp(angleToShooting, minAngle, maxAngle);
        DirectionUp();
        DirectionDown();
        towerTransform.localEulerAngles = new Vector3(0, transform.rotation.y, angleToShooting);
    }

    private void DirectionUp()
    {
        if (Input.GetKey(keyUP))
        {
            angleToShooting += 1f;
        }
    }

    private void DirectionDown()
    {
        if (Input.GetKey(keyDown))
        {
            angleToShooting -= 1f;
        }
    }
}
