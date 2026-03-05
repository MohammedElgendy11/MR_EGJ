using UnityEngine;

using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Coroutine _animationCoroutine;
    private Vector3 _initialScale;

    private void Awake()
    {
        _initialScale = transform.localScale;
    }

    public void Press()
    {
        keypad.AddNumber(value);
        PlayPressAnimation();
    }

    private void PlayPressAnimation()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }
        _animationCoroutine = StartCoroutine(AnimateScale());
    }

    private IEnumerator AnimateScale()
    {
        Vector3 targetScale = _initialScale * 0.9f;
        float halfDuration = 0.05f;

        // Scale down
        float time = 0;
        while (time < halfDuration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_initialScale, targetScale, time / halfDuration);
            yield return null;
        }

        // Scale up
        time = 0;
        while (time < halfDuration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, _initialScale, time / halfDuration);
            yield return null;
        }

        transform.localScale = _initialScale;
    }

    private void OnDisable()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }
        transform.localScale = _initialScale;
    }
}
