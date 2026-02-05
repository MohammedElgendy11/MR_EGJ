using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzles")]
    [SerializeField] private List<PuzzleData> puzzles;

    private int currentPuzzleIndex = 0;

    [Header("References")]
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;

    private PuzzleData currentPuzzle;

    void Start()
    {
        LoadPuzzle();
    }

    void LoadPuzzle()
    {
        if (currentPuzzleIndex >= puzzles.Count)
        {
            Debug.Log("All puzzles solved!");
            return;
        }

        currentPuzzle = puzzles[currentPuzzleIndex];
        scoreManager.SetScore(currentPuzzle.baseScore);
        puzzleUI.LoadPuzzle(currentPuzzle);
    }

    public void OnPuzzleSolved()
    {
        currentPuzzleIndex++;
        LoadPuzzle();
    }

    public bool CheckAnswer(string input)
    {
        return input == currentPuzzle.correctAnswer;
    }
}
