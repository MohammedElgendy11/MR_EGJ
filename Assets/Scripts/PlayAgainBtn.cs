using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private bool isTransitioning = false;
    private Vector3 originalScale;

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

        // Scale down
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 0.9f, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        transform.localScale = originalScale * 0.9f;

        // Scale up
        elapsed = 0f;
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
