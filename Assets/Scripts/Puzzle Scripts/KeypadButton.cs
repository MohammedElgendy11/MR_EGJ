using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 initialScale;
    private Coroutine scaleCoroutine;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
            scaleCoroutine = null;
        }
        transform.localScale = initialScale;
    }

    public void Press()
    {
        keypad.AddNumber(value);

        if (gameObject.activeInHierarchy)
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
            scaleCoroutine = StartCoroutine(AnimatePress());
        }
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        float elapsed = 0f;
        Vector3 targetScale = initialScale * 0.9f;

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / halfDuration);
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsed / halfDuration);
            yield return null;
        }

        transform.localScale = initialScale;
        scaleCoroutine = null;
    }
}
