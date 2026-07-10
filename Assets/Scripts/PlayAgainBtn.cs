using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine feedbackCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        if (feedbackCoroutine != null)
        {
            StopCoroutine(feedbackCoroutine);
            feedbackCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (feedbackCoroutine != null)
        {
            StopCoroutine(feedbackCoroutine);
        }
        feedbackCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.075f; // Half of ~0.15s for scale down
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
