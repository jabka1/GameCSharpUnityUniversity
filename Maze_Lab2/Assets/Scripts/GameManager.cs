using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
        if (score == 50){
            scoreText.text = "<color=green>Congratulations! You win!</color>";
        }
    }

    void UpdateScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }
}
