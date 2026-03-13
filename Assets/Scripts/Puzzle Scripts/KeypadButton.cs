using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 originalScale;
    private Coroutine scaleCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void Press()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = StartCoroutine(ButtonPressEffect());

        keypad.AddNumber(value);
    }

    private IEnumerator ButtonPressEffect()
    {
        float duration = 0.05f;
        Vector3 targetScale = originalScale * 0.9f;

        // Scale down
        float time = 0;
        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        time = 0;
        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}
