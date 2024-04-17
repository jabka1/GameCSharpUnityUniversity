using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    public float rotationSpeed = 1000f;

    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }
}
