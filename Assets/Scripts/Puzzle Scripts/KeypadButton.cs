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

        if (gameObject.activeInHierarchy)
        {
            if (pressCoroutine != null)
                StopCoroutine(pressCoroutine);
            pressCoroutine = StartCoroutine(PressAnimation());
        }
    }

    private IEnumerator PressAnimation()
    {
        Vector3 targetScale = initialScale * 0.9f;
        float duration = 0.05f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }

        elapsed = 0f;

        // Scale up
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, t);
            yield return null;
        }

        transform.localScale = initialScale;
    }
}
