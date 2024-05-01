using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public float speed = 10f;
    private float direction = -1f;

    void Update()
    {
        // Рух капсули вздовж осі Z
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            direction *= -1f;
        }
    }
}
