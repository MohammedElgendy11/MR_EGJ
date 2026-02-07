using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void DecreaseScore(int amount)
    {
        score = Mathf.Max(0, score - amount);
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
    }
}
