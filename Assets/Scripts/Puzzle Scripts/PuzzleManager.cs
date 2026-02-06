using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzles")]
    [SerializeField] private List<PuzzleData> puzzles;

    [Header("References")]
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private KeypadController keypad;

    private int currentPuzzleIndex = 0;
    private PuzzleData currentPuzzle;

    void Start()
    {
        LoadPuzzle();
    }

    void LoadPuzzle()
    {
        if (currentPuzzleIndex >= puzzles.Count)
        {
            Debug.Log("ALL PUZZLES SOLVED");
            return;
        }

        currentPuzzle = puzzles[currentPuzzleIndex];

        scoreManager.SetScore(currentPuzzle.baseScore);
        puzzleUI.LoadPuzzle(currentPuzzle);
        keypad.SetCorrectAnswer(currentPuzzle.correctAnswer);
    }

    public void OnPuzzleSolved()
    {
        currentPuzzleIndex++;
        LoadPuzzle();
    }
}
