using UnityEngine;
using System.Collections;

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
        StopAllCoroutines();
        StartCoroutine(AnimateButtonPress());

        puzzleUI.ShowNextHint();
        scoreManager.DecreaseScore(hintPenalty);
    }

    private IEnumerator AnimateButtonPress()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = initialScale * 0.9f;

        while (elapsed < duration / 2)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / (duration / 2));
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < duration / 2)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsed / (duration / 2));
            yield return null;
        }

        transform.localScale = initialScale;
    }
}
