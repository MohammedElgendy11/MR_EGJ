using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float timeInSeconds = 180f;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool isRunning = true;

    void Update()
    {
        if (!isRunning)
            return;

        timeInSeconds -= Time.deltaTime;

        if (timeInSeconds <= 0)
        {
            timeInSeconds = 0;
            isRunning = false;
            Debug.Log("Time Over!");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}

