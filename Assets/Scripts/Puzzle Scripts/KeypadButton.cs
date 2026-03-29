using UnityEngine;

using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 _initialScale;
    private Coroutine _pressCoroutine;

    private void Awake()
    {
        _initialScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _initialScale;
    }

    public void Press()
    {
        keypad.AddNumber(value);

        if (gameObject.activeInHierarchy)
        {
            if (_pressCoroutine != null)
            {
                StopCoroutine(_pressCoroutine);
            }
            _pressCoroutine = StartCoroutine(AnimatePress());
        }
    }

    private IEnumerator AnimatePress()
    {
        float duration = 0.1f;
        float halfDuration = duration / 2f;
        float elapsed = 0f;

        Vector3 targetScale = _initialScale * 0.9f;

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_initialScale, targetScale, elapsed / halfDuration);
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, _initialScale, elapsed / halfDuration);
            yield return null;
        }

        transform.localScale = _initialScale;
    }
}
