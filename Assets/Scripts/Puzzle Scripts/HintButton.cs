using UnityEngine;
using System.Collections;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    private Coroutine scaleCoroutine;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void OnHintPressed()
    {
        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);

        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(AnimateButton());
    }

    private IEnumerator AnimateButton()
    {
        Vector3 targetScale = originalScale * 0.9f;
        float halfDuration = 0.05f; // 0.1s total duration
        float elapsed = 0f;

        // Scale down
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / halfDuration);
            yield return null;
        }
        transform.localScale = targetScale;

        elapsed = 0f;

        // Scale up
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / halfDuration);
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
