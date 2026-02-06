using UnityEngine;
using TMPro;

public class PuzzleUIController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] hintTexts;
    [SerializeField] private GameObject[] hintPanels;
    [SerializeField] private GameObject hintButton;

    private PuzzleData currentPuzzle;
    private int hintIndex;

    public void LoadPuzzle(PuzzleData puzzle)
    {
        currentPuzzle = puzzle;
        questionText.text = puzzle.question;

        hintIndex = 0;

        // Reset all hints & panels
        for (int i = 0; i < hintTexts.Length; i++)
        {
            hintTexts[i].text = "";
            hintTexts[i].gameObject.SetActive(false);
            hintPanels[i].SetActive(false);
        }

        hintButton.SetActive(true);
    }

    public void ShowNextHint()
    {
        if (hintIndex >= currentPuzzle.hints.Length)
            return;

        // Activate only the current hint panel
        hintPanels[hintIndex].SetActive(true);
        hintTexts[hintIndex].gameObject.SetActive(true);
        hintTexts[hintIndex].text = currentPuzzle.hints[hintIndex];

        hintIndex++;

        if (hintIndex >= currentPuzzle.hints.Length)
            hintButton.SetActive(false);
    }
}
