using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine interactionCoroutine;
    private readonly float animationDuration = 0.15f;
    private readonly float scaleDownFactor = 0.85f;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
            interactionCoroutine = null;
        }
        transform.localScale = originalScale;
    }

    public void PlayAgain()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
        }
        interactionCoroutine = StartCoroutine(ProvideFeedbackAndLoadScene());
    }

    private IEnumerator ProvideFeedbackAndLoadScene()
    {
        Vector3 targetScale = originalScale * scaleDownFactor;
        float elapsedTime = 0f;

        // Scale down
        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / animationDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = originalScale;

        // Execute action
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
