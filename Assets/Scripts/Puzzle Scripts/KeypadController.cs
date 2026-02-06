using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI displayText;

    [Header("Settings")]
    [SerializeField] private int maxLength = 6;

    [Header("References")]
    [SerializeField] private PuzzleManager puzzleManager;

    private string correctAnswer;
    private string currentInput = "";

    void Start()
    {
        UpdateDisplay();
    }

    public void SetCorrectAnswer(string answer)
    {
        correctAnswer = answer;
        ClearAll();
    }

    #region Buttons

    public void AddNumber(string number)
    {
        if (currentInput.Length >= maxLength)
            return;

        currentInput += number;
        UpdateDisplay();
    }

    public void RemoveLast()
    {
        if (currentInput.Length == 0)
            return;

        currentInput = currentInput.Substring(0, currentInput.Length - 1);
        UpdateDisplay();
    }

    public void ClearAll()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void Submit()
    {
        if (currentInput == correctAnswer)
        {
            puzzleManager.OnPuzzleSolved();
        }
        else
        {
            Debug.Log("WRONG PASSWORD");
        }

        ClearAll();
    }

    #endregion

    void UpdateDisplay()
    {
        displayText.text = string.IsNullOrEmpty(currentInput) ? "----" : currentInput;
    }
}
