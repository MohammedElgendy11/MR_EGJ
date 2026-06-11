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
        _feedbackCoroutine = StartCoroutine(ProvideTactileFeedbackAndLoad());
    }

    private IEnumerator ProvideTactileFeedbackAndLoad()
    {
        Vector3 targetScale = _originalScale * 0.9f;
        float duration = 0.15f;
        float halfDuration = duration / 2f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / halfDuration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Scale up
        while (elapsed < halfDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / halfDuration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
