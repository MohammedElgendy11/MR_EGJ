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
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
        }
    }

    public void Press()
    {
        keypad.AddNumber(value);

        if (gameObject.activeInHierarchy)
        {
            if (pressCoroutine != null)
            {
                StopCoroutine(pressCoroutine);
            }
            pressCoroutine = StartCoroutine(AnimatePress());
        }
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        Vector3 targetScale = initialScale * 0.9f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
        elapsed = 0f;

        // Scale back up
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, t);
            yield return null;
        }

        transform.localScale = initialScale;
        pressCoroutine = null;
    }
}
