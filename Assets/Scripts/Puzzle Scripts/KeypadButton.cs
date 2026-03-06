using System.Collections;
using UnityEngine;

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
        keypad.AddNumber(value);

        StopAllCoroutines();
        StartCoroutine(PressAnimation());
    }

    private IEnumerator PressAnimation()
    {
        Vector3 pressedScale = initialScale * 0.9f;
        float duration = 0.05f;
        float elapsed = 0f;

        // Scale down
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, pressedScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Scale up
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(pressedScale, initialScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = initialScale;
    }
}
