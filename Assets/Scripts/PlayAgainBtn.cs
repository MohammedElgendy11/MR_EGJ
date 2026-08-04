using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private bool isTransitioning = false;
    private Vector3 originalScale;
    private Coroutine transitionCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (isTransitioning)
        {
            transform.localScale = originalScale;
            isTransitioning = false;
        }
    }

    public void PlayAgain()
    {
        if (isTransitioning) return;
        isTransitioning = true;

        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.15f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        while (elapsed < duration / 2f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / (duration / 2f));
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / (duration / 2f));
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
