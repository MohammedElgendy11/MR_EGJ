using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine interactionCoroutine;

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
        interactionCoroutine = StartCoroutine(HandleInteractionCoroutine());
    }

    private IEnumerator HandleInteractionCoroutine()
    {
        // Visual tactile feedback: scale down
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);

        // Restore scale
        transform.localScale = originalScale;
        yield return new WaitForSeconds(0.05f); // Brief pause before loading scene

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
