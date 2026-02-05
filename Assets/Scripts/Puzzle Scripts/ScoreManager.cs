using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    public void SetScore(int value)
    {
        score = value;
        UpdateUI();
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        score = Mathf.Max(0, score);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }
}
