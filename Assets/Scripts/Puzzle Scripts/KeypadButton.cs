using UnityEngine;

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
            {
                StopCoroutine(pressCoroutine);
            }
            pressCoroutine = StartCoroutine(PressAnimation());
        }
    }

    private System.Collections.IEnumerator PressAnimation()
    {
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        Vector3 targetScale = initialScale * 0.9f;

        float elapsed = 0f;
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
    }
}
