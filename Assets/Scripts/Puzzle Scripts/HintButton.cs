using UnityEngine;

using System.Collections;

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
            pressCoroutine = StartCoroutine(AnimatePress());
        }
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        Vector3 targetScale = initialScale * 0.9f;

        float time = 0;
        while (time < halfDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        time = 0;
        while (time < halfDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, initialScale, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = initialScale;
        pressCoroutine = null;
    }
}
