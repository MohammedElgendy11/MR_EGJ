using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

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
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
            scaleCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(AnimateAndLoad());
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
            float t = elapsed / (duration / 2);
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        elapsed = 0f;

        // Scale back up
        while (elapsed < duration / 2)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / (duration / 2);
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
