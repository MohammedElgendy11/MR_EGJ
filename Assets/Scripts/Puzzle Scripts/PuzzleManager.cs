using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzles")]
    [SerializeField] private List<PuzzleData> puzzles;

    [Header("References")]
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private GameObject KeyPadUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private KeypadController keypad;

    private int currentPuzzleIndex = 0;

    void Start()
    {
        LoadPuzzle();
    }

    void LoadPuzzle()
    {
        if (currentPuzzleIndex >= puzzles.Count)
        {
            puzzleUI.gameObject.SetActive(false);
            KeyPadUI.SetActive(false);
            return;
        }

        PuzzleData puzzle = puzzles[currentPuzzleIndex];

        scoreManager.AddScore(puzzle.baseScore);
        puzzleUI.LoadPuzzle(puzzle);
        keypad.correctPassword = puzzle.correctAnswer;
    }

    public void OnPuzzleSolved()
    {
        currentPuzzleIndex++;
        LoadPuzzle();
    }
}
