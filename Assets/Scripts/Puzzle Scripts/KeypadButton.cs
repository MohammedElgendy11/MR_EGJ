using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 originalScale;
    private Coroutine pressCoroutine;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void Press()
    {
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
        }
        pressCoroutine = StartCoroutine(PressAnimation());

        keypad.AddNumber(value);
    }

    private IEnumerator PressAnimation()
    {
        float duration = 0.05f;
        float elapsed = 0f;
        Vector3 targetScale = originalScale * 0.9f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale back up
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
