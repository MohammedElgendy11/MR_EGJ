using UnityEngine;

using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 initialScale;
    private Coroutine pressCoroutine;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = initialScale;
    }

    public void Press()
    {
        keypad.AddNumber(value);

        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
        }
        pressCoroutine = StartCoroutine(AnimatePress());
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.05f;
        Vector3 targetScale = initialScale * 0.9f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = initialScale;
        pressCoroutine = null;
    }
}
