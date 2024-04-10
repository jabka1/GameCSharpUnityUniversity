using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxSpeed = 15f;
    public float lookSpeed = 10f;
    public float speedDamping = 2f;

    public Transform cameraPivot;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 previousMousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forwardDirection = cameraPivot.forward;
        forwardDirection.y = 0;
        moveDirection = forwardDirection.normalized;

        Vector3 rightDirection = cameraPivot.right;
        rightDirection.y = 0;

        Vector3 movement = (rightDirection * horizontalInput + moveDirection * verticalInput).normalized;

        if (movement.magnitude > 0)
        {
            rb.AddForce(movement * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        rb.velocity *= Mathf.Pow(speedDamping, Time.deltaTime);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float deltaX = mouseDelta.x * lookSpeed * Time.deltaTime;
            cameraPivot.Rotate(Vector3.up, deltaX);
        }

        previousMousePosition = Input.mousePosition;
    }
}
