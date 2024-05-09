using UnityEngine;
using Photon.Pun;

public class BallController : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 10f;
    public float maxSpeed = 15f;
    public float lookSpeed = 10f;
    public float speedDamping = 2f;

    private Rigidbody rb;
    private Vector3 previousMousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (photonView.IsMine){
            rb.isKinematic = false;
        }
        else{
            rb.isKinematic = true;
        }
    }

    void FixedUpdate(){
        if (photonView.IsMine){
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
            if (movement.magnitude > 0){
                rb.AddForce(movement.normalized * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            rb.velocity *= Mathf.Pow(speedDamping, Time.deltaTime);
            if (rb.velocity.magnitude > maxSpeed){
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            if (Input.GetMouseButton(0)){
                Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
                float deltaX = mouseDelta.x * lookSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, deltaX);
            }
            previousMousePosition = Input.mousePosition;
        }
    }
}
