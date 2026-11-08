using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isLoading = false;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        isLoading = false;
    }

    public void PlayAgain()
    {
        if (isLoading) return;
        isLoading = true;
        StartCoroutine(ProvideFeedbackAndLoad());
    }

    private System.Collections.IEnumerator ProvideFeedbackAndLoad()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        yield return new WaitForSecondsRealtime(0.05f);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
