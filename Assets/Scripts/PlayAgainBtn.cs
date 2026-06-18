using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private Coroutine _interactionCoroutine;
    private bool _isInitialized;

    private void Awake()
    {
        _originalScale = transform.localScale;
        _isInitialized = true;
    }

    private void OnDisable()
    {
        if (_isInitialized)
        {
            transform.localScale = _originalScale;
        }
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
        _interactionCoroutine = StartCoroutine(PlayAgainRoutine());
    }

    private IEnumerator PlayAgainRoutine()
    {
        float duration = 0.15f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale down
        while (elapsed < duration / 2f)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / (duration / 2f);
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, t);
            yield return null;
        }

        // Scale up
        elapsed = 0f;
        while (elapsed < duration / 2f)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / (duration / 2f);
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, t);
            yield return null;
        }

        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
