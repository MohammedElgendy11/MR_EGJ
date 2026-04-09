using System.Collections;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField] private PuzzleUIController puzzleUI;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int hintPenalty = 100;

    private Vector3 initialScale;
    private Coroutine pressCoroutine;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
        }
        transform.localScale = initialScale;
    }

    public void OnHintPressed()
    {
        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);

        if (gameObject.activeInHierarchy)
        {
            if (pressCoroutine != null)
            {
                StopCoroutine(pressCoroutine);
            }
            pressCoroutine = StartCoroutine(PressAnimation());
        }
    }

    private IEnumerator PressAnimation()
    {
        Vector3 targetScale = initialScale * 0.9f;
        float duration = 0.05f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = initialScale;

        pressCoroutine = null;
    }
}
