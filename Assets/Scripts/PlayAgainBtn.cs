using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine interactionCoroutine;
    private readonly float scaleFactor = 0.9f;
    private readonly float animationDuration = 0.1f;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
            interactionCoroutine = null;
        }
    }

    public void PlayAgain()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
        }
        interactionCoroutine = StartCoroutine(ProvideTactileFeedbackAndLoadScene());
    }

    private IEnumerator ProvideTactileFeedbackAndLoadScene()
    {
        Vector3 targetScale = originalScale * scaleFactor;
        float elapsedTime = 0f;

        // Scale down
        while (elapsedTime < animationDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / (animationDuration / 2f));
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        elapsedTime = 0f;

        // Scale up
        while (elapsedTime < animationDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / (animationDuration / 2f));
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = originalScale;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
