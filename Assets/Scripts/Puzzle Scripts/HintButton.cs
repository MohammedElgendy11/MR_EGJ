using System.Collections;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = initialScale;
    }

    public void OnHintPressed()
    {
        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);

        StopAllCoroutines();
        StartCoroutine(PressAnimation());
    }

    private IEnumerator PressAnimation()
    {
        Vector3 pressedScale = initialScale * 0.9f;
        float duration = 0.05f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, pressedScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Scale up
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(pressedScale, initialScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = initialScale;
    }
}
