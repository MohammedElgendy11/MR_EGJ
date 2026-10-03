using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private bool _isTransitioning = false;
    private Vector3 _originalScale;

    private void Awake()
    {
        if (transform != null)
        {
            _originalScale = transform.localScale;
        }
    }

    private void OnDisable()
    {
        if (transform != null)
        {
            transform.localScale = _originalScale;
        }
    }

    public void PlayAgain()
    {
        if (_isTransitioning) return;
        _isTransitioning = true;
        StartCoroutine(ProvideTactileFeedbackAndLoadScene());
    }

    // Public only for testing purposes using shims.
    public IEnumerator ProvideTactileFeedbackAndLoadScene()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = _originalScale * 0.9f;

        // Scale down
        while (elapsed < duration)
        {
            if (transform != null)
            {
                transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            }
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        // Snap to target to ensure precision at end of Lerp
        if (transform != null) transform.localScale = targetScale;

        elapsed = 0f;
        // Scale back up
        while (elapsed < duration)
        {
            if (transform != null)
            {
                transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            }
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        if (transform != null) transform.localScale = _originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
