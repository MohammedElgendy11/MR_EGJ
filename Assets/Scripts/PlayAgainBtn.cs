using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isTransitioning = false;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        isTransitioning = false;
    }

    public void PlayAgain()
    {
        if (isTransitioning) return;
        isTransitioning = true;
        StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.075f; // half duration for down, half for up
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
