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
        if (transform != null)
        {
            transform.localScale = originalScale;
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
            pressCoroutine = StartCoroutine(PressAnimation());
        }
    }

    private IEnumerator PressAnimation()
    {
        // Scale down slightly
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);

        // Return to original scale
        transform.localScale = originalScale;

        pressCoroutine = null;
    }
}
