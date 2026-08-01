using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private Coroutine _interactionCoroutine;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
        if (_interactionCoroutine != null)
        {
            StopCoroutine(_interactionCoroutine);
            _interactionCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (_interactionCoroutine != null)
        {
            StopCoroutine(_interactionCoroutine);
        }
        _interactionCoroutine = StartCoroutine(AnimateAndLoad());
    }

    private IEnumerator AnimateAndLoad()
    {
        float duration = 0.075f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale Down
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale Up
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
