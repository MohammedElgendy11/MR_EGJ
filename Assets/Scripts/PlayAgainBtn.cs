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
        // Brief scale down
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);

        // Scale back up
        transform.localScale = originalScale;
        yield return new WaitForSeconds(0.05f); // Brief pause before loading

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
