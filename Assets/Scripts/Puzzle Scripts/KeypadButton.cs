using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    [Header("Feedback")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pressSound;
    [SerializeField] private float pressScale = 0.9f;
    [SerializeField] private float animationDuration = 0.1f;

    private Vector3 initialScale;
    private Coroutine animationCoroutine;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        // Reset scale in case we are disabled mid-animation
        transform.localScale = initialScale;
        animationCoroutine = null;
    }

    public void Press()
    {
        keypad.AddNumber(value);

        // Visual Feedback
        if (isActiveAndEnabled)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            animationCoroutine = StartCoroutine(AnimateButton());
        }

        // Audio Feedback
        if (audioSource != null && pressSound != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
        else if (pressSound != null)
        {
            AudioSource.PlayClipAtPoint(pressSound, transform.position);
        }
    }

    private IEnumerator AnimateButton()
    {
        float halfDuration = animationDuration / 2f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(initialScale, initialScale * pressScale, t);
            yield return null;
        }

        transform.localScale = initialScale * pressScale;
        elapsed = 0f;

        // Scale up
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(initialScale * pressScale, initialScale, t);
            yield return null;
        }

        transform.localScale = initialScale;
        animationCoroutine = null;
    }
}
