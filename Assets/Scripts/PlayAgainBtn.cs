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
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }
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
        float duration = 0.075f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale down
        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, time / duration);
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, time / duration);
            yield return null;
        }
        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
