using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine activeAnimation;

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
        if (activeAnimation != null)
        {
            StopCoroutine(activeAnimation);
        }
        activeAnimation = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.15f;
        float elapsed = 0f;

        Vector3 targetScale = originalScale * 0.9f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            float scaleValue = Mathf.Lerp(originalScale.x, targetScale.x, t);
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = targetScale;

        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;

            float scaleValue = Mathf.Lerp(targetScale.x, originalScale.x, t);
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
