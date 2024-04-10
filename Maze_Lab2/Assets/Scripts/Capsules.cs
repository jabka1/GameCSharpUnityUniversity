using UnityEngine;

public class Capsules : MonoBehaviour
{
    public int points = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
