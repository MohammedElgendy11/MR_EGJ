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
        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
            pressCoroutine = null;
        }
        transform.localScale = initialScale;
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

        float time = 0;
        while (time < halfDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        time = 0;
        while (time < halfDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, initialScale, time / halfDuration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = initialScale;
        pressCoroutine = null;
    }
}
