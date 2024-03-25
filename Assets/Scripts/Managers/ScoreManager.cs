using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent OnScoreUpdated;
    private int score;

    private int highScore;

    void Start()
    {
        RetrieveHighScore();
    }

    public int GetHighScore()
    {
        return highScore;
    }
    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score++;
        SetHighScore();
        OnScoreUpdated?.Invoke();
    }

    private void SetHighScore()
    {
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        RetrieveHighScore();
    }

    private void RetrieveHighScore()
    {
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            highScore = PlayerPrefs.GetInt("HIGHSCORE");
        }
        else
        {
            PlayerPrefs.SetInt("HIGHSCORE", highScore);
        }
        OnScoreUpdated.Invoke();
    }
}
