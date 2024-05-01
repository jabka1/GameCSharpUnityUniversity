using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public bool touchedCone1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 25f;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        rb.AddForce(Physics.gravity * rb.mass);
        if (!touchedCone1)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed;
            rb.velocity = movement;
        }
        else
        {
            moveHorizontal *= -1;
            moveVertical *= -1;
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * speed;
            rb.velocity = movement;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cone1"))
        {
            touchedCone1 = true;
        }
    }
}
