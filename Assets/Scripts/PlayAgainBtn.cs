using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private bool _isTransitioning = false;
    private Coroutine _animationCoroutine;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
        _isTransitioning = false;
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (_isTransitioning) return;
        _isTransitioning = true;

        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }

        _animationCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.075f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
