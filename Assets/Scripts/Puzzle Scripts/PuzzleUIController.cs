using UnityEngine;
using TMPro;

public class PuzzleUIController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] hintTexts;
    [SerializeField] private GameObject hintButton;

    private PuzzleData currentPuzzle;
    private int hintIndex = 0;

    public void LoadPuzzle(PuzzleData puzzle)
    {
        currentPuzzle = puzzle;

        questionText.text = puzzle.question;
        hintIndex = 0;

        for (int i = 0; i < hintTexts.Length; i++)
        {
            hintTexts[i].gameObject.SetActive(false);
            hintTexts[i].text = "";
        }

        hintButton.SetActive(true);
    }

    public void ShowNextHint()
    {
        if (hintIndex >= currentPuzzle.hints.Length)
            return;

        hintTexts[hintIndex].text = currentPuzzle.hints[hintIndex];
        hintTexts[hintIndex].gameObject.SetActive(true);

        hintIndex++;

        if (hintIndex >= currentPuzzle.hints.Length)
            hintButton.SetActive(false);
    }

    public int GetUsedHints()
    {
        return hintIndex;
    }
}
