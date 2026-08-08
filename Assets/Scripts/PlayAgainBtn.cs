using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private Coroutine _feedbackCoroutine;
    private bool _isTransitioning;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
        _isTransitioning = false;
    }

    public void PlayAgain()
    {
        if (_isTransitioning) return;

        if (_feedbackCoroutine != null)
        {
            StopCoroutine(_feedbackCoroutine);
        }

        _feedbackCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        _isTransitioning = true;
        float duration = 0.075f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale Down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        transform.localScale = targetScale;

        // Scale Up
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }
        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
