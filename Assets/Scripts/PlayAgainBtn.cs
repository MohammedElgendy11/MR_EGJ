using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine animationCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
        transform.localScale = originalScale;
    }

    public void PlayAgain()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.15f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        // Scale down
        while (elapsed < duration / 2)
        {
            elapsed += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / (duration / 2));
            yield return null;
        }

        elapsed = 0f;

        // Scale up
        while (elapsed < duration / 2)
        {
            elapsed += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / (duration / 2));
            yield return null;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
