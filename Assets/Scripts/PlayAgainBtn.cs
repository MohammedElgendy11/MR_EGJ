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
        StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        isTransitioning = true;
        float duration = 0.1f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 0.9f, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        elapsed = 0f;
        // Scale up
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale * 0.9f, originalScale, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
