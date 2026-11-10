using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private bool isLoading = false;
    private Vector3 originalScale;

    // Exposed for testing
    public Coroutine? currentCoroutine { get; private set; }

    public void Awake()
    {
        if (transform != null)
        {
            originalScale = transform.localScale;
        }
    }

    public void OnDisable()
    {
        if (transform != null)
        {
            transform.localScale = originalScale;
        }
        isLoading = false;
    }

    public void PlayAgain()
    {
        if (isLoading) return;
        isLoading = true;
        currentCoroutine = StartCoroutine(ProvideFeedbackAndLoad());
    }

    private IEnumerator ProvideFeedbackAndLoad()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        // Down phase
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Up phase
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
