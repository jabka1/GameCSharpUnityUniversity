using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    private bool touchedCone1 = false;

    public TextMeshProUGUI statusText;

    void Start(){
        UpdateStatusText("Make your way to the cone on the other side!");
    }

    void Update()
    {
        if (!gameEnded)
        {
            CheckPlayerTouchCones();
            CheckPlayerCollisionWithEnemy();
            CheckPlayerFall();
        }
    }

    void CheckPlayerCollisionWithEnemy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(player.transform.position, enemy.transform.position) < 1.0f)
            {
                EndGame("You lost! The player touched the enemy.");
                break;
            }
        }
    }

    void CheckPlayerFall()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && player.transform.position.y < 0)
        {
            EndGame("You lost! The player fell from below.");
        }
    }

    void CheckPlayerTouchCones()
    {
        GameObject cone1 = GameObject.FindGameObjectWithTag("Cone1");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(player.transform.position, cone1.transform.position) < 1.0f)
        {
            touchedCone1 = true;
            UpdateStatusText("Player touched cone 1!");
        }

        if (touchedCone1)
        {
            GameObject cone2 = GameObject.FindGameObjectWithTag("Cone2");
            if (Vector3.Distance(player.transform.position, cone2.transform.position) < 1.0f)
            {
                EndGame("You won! Player touched cone 2!");
            }
        }
    }

    void UpdateStatusText(string text)
    {
        if (statusText != null)
        {
            statusText.text = text;
        }
    }

    void EndGame(string message)
    {
        gameEnded = true;
        Time.timeScale = 0f;
        UpdateStatusText(message);
    }
}