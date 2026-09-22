using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 _originalScale;
    private bool _isTransitioning = false;

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
        _isTransitioning = true;

        StartCoroutine(TactileFeedbackRoutine());
    }

    private IEnumerator TactileFeedbackRoutine()
    {
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
