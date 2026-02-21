using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    [Header("Feedback")]
    [SerializeField] private float pressScale = 0.9f;
    [SerializeField] private float animationDuration = 0.1f;

    private Vector3 originalScale;
    private Coroutine pressCoroutine;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void Press()
    {
        if (keypad != null)
            keypad.AddNumber(value);

        if (pressCoroutine != null)
            StopCoroutine(pressCoroutine);

        pressCoroutine = StartCoroutine(AnimateButton());
    }

    private IEnumerator AnimateButton()
    {
        // Scale down
        float elapsed = 0f;
        Vector3 targetScale = originalScale * pressScale;

        while (elapsed < animationDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale up
        elapsed = 0f;
        while (elapsed < animationDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;

        pressCoroutine = null;
    }
}
