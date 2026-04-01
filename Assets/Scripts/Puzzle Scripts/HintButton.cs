using UnityEngine;
using System.Collections;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    private Vector3 originalScale;
    private Coroutine pressCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
        }
    }

    public void OnHintPressed()
    {
        if (gameObject.activeInHierarchy)
        {
            if (pressCoroutine != null)
            {
                StopCoroutine(pressCoroutine);
            }
            pressCoroutine = StartCoroutine(AnimatePress());
        }

        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);
    }

    private IEnumerator AnimatePress()
    {
        Vector3 targetScale = originalScale * 0.9f;
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
        pressCoroutine = null;
    }
}
