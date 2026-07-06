using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private Coroutine _animationCoroutine;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
    }

    public void PlayAgain()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }
        _animationCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.15f;
        float halfDuration = duration / 2f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale down
        float elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / halfDuration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        transform.localScale = targetScale;

        // Scale back up
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / halfDuration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
