using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 initialScale;

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
        StopAllCoroutines();
        StartCoroutine(AnimateButtonPress());

        keypad.AddNumber(value);
    }

    private IEnumerator AnimateButtonPress()
    {
        float duration = 0.1f;
        float elapsed = 0f;
        Vector3 targetScale = initialScale * 0.9f;

        while (elapsed < duration / 2)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / (duration / 2));
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < duration / 2)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsed / (duration / 2));
            yield return null;
        }

        transform.localScale = initialScale;
    }
}
