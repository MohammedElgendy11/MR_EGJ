using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    [SerializeField] private AudioSource audioSource;
    private Coroutine pressCoroutine;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
        }
        transform.localScale = originalScale;
    }

    public void Press()
    {
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
        }
        pressCoroutine = StartCoroutine(AnimatePress());

        if (audioSource != null)
        {
            audioSource.Play();
        }

        keypad.AddNumber(value);
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.05f;
        Vector3 targetScale = originalScale * 0.9f;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
