using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Coroutine _feedbackCoroutine;
    private Vector3 _originalScale;

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
        if (_feedbackCoroutine == null)
        {
            _feedbackCoroutine = StartCoroutine(TactileFeedbackAndLoad());
        }
    }

    private IEnumerator TactileFeedbackAndLoad()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Shrink
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Grow back
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = _originalScale;

        // Load scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}