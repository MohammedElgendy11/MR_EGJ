using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    }

    public void PlayAgain()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
        }
        interactionCoroutine = StartCoroutine(ProvideTactileFeedbackAndLoad());
    }

    private IEnumerator ProvideTactileFeedbackAndLoad()
    {
        // Scale down for visual click feedback
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);

        // Scale back up
        transform.localScale = originalScale;
        yield return new WaitForSeconds(0.05f);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
