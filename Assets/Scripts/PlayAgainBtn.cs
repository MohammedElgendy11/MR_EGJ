using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        float duration = 0.15f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // Scale down then up
            if (elapsed < duration / 2f)
            {
                float tHalf = elapsed / (duration / 2f);
                transform.localScale = Vector3.Lerp(originalScale, targetScale, tHalf);
            }
            else
            {
                float tHalf = (elapsed - duration / 2f) / (duration / 2f);
                transform.localScale = Vector3.Lerp(targetScale, originalScale, tHalf);
            }

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
