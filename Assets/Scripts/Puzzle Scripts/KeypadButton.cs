using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
    }

    public void Press()
    {
        StartCoroutine(AnimatePress());
        keypad.AddNumber(value);
    }

    private System.Collections.IEnumerator AnimatePress()
    {
        float duration = 0.1f;
        float elapsed = 0f;

        // Scale down to 90%
        Vector3 targetScale = _originalScale * 0.9f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = targetScale;

        // Scale back up to 100%
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, elapsed / duration);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localScale = _originalScale;
    }
}
