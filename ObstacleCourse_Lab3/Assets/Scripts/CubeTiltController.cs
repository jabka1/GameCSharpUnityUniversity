using UnityEngine;

public class CubeTiltController : MonoBehaviour
{
    public float tiltAngle = 45f;

    void Update()
    {
        float tiltAmount = Mathf.Sin(Time.time) * tiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, tiltAmount);
        transform.rotation = targetRotation;
    }
}
