using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine scaleCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void PlayAgain()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(ScaleAndTransition());
    }

    private IEnumerator ScaleAndTransition()
    {
        float targetScaleMultiplier = 0.9f;
        float duration = 0.1f;
        float elapsed = 0f;

        Vector3 targetScale = originalScale * targetScaleMultiplier;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        elapsed = 0f;

        // Scale back up
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = originalScale;

        // Perform transition after feedback
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
