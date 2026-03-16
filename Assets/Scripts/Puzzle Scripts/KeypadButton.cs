using UnityEngine;

using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 originalScale;
    private Coroutine pressCoroutine;

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
        if (pressCoroutine != null) StopCoroutine(pressCoroutine);
        pressCoroutine = StartCoroutine(AnimatePress());
        keypad.AddNumber(value);
    }

    private IEnumerator AnimatePress()
    {
        Vector3 targetScale = originalScale * 0.9f;
        float duration = 0.05f;
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

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
