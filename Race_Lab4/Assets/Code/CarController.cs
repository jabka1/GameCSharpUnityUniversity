using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{
    public float baseSpeed = 10f; 
    public float maxY = 3.5f; 
    public float minY = -3.5f; 

    public TMP_Text collisionText;

    void Update()
    {
        float speed = baseSpeed;
        float verticalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0f, verticalInput, 0f) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OpponentCar"))
        {
            collisionText.text = "Defeat";
            Time.timeScale = 0;
        }
    }
}
