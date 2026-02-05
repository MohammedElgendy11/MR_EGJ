using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    public void OnHintPressed()
    {
        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);
    }
}
