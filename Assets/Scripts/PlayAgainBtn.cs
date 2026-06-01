using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private Coroutine _feedbackCoroutine;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
        if (_feedbackCoroutine != null)
        {
            StopCoroutine(_feedbackCoroutine);
            _feedbackCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (_feedbackCoroutine != null)
        {
            StopCoroutine(_feedbackCoroutine);
        }
        _feedbackCoroutine = StartCoroutine(ProvideFeedbackAndLoad());
    }

    private IEnumerator ProvideFeedbackAndLoad()
    {
        // Scale down quickly
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale back up
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = _originalScale;

        // Perform the action
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
