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
        feedbackCoroutine = StartCoroutine(ProvideFeedbackAndLoad());
    }

    private IEnumerator ProvideFeedbackAndLoad()
    {
        float duration = 0.1f;
        Vector3 targetScale = originalScale * 0.9f;

        // Scale down
        float time = 0;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        time = 0;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, time / duration);
            yield return null;
        }
        transform.localScale = originalScale;

        // Load scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
