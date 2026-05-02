using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayAgainBtn : MonoBehaviour
{
    private Vector3 originalScale;
    private Coroutine feedbackCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (originalScale != Vector3.zero)
        {
            transform.localScale = originalScale;
        }
    }

    public void PlayAgain()
    {
        if (feedbackCoroutine != null)
        {
            StopCoroutine(feedbackCoroutine);
        }
        feedbackCoroutine = StartCoroutine(ProvideFeedbackAndLoad());
    }

    private IEnumerator ProvideFeedbackAndLoad()
    {
        // Scale down
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);

        // Scale back up
        transform.localScale = originalScale;
        yield return new WaitForSeconds(0.05f); // Brief pause before scene load

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
