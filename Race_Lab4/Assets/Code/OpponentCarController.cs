using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    public float baseSpeed = 7f;
    public float maxX = 12f;
    public float minY = -3.5f;
    public float maxY = 3.5f;
    public float speedIncreaseInterval = 15f;
    public float speedIncreaseAmount = 5f;

    private float currentSpeed;
    private float timeSinceLastSpeedIncrease = 0f;

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);

        if (transform.position.x > maxX)
        {
            float randomY = Random.Range(minY, maxY);
            transform.position = new Vector3(-maxX, randomY, transform.position.z);
        }

        timeSinceLastSpeedIncrease += Time.deltaTime;

        if (timeSinceLastSpeedIncrease >= speedIncreaseInterval)
        {
            currentSpeed += speedIncreaseAmount;
            timeSinceLastSpeedIncrease = 0f;
        }
    }
}
