using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 _originalScale;
    private Coroutine _pressCoroutine;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = _originalScale;
        if (_pressCoroutine != null)
        {
            StopCoroutine(_pressCoroutine);
            _pressCoroutine = null;
        }
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
            _pressCoroutine = StartCoroutine(VisualPressFeedback());
        }
    }

    private IEnumerator VisualPressFeedback()
    {
        transform.localScale = _originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = _originalScale;
        _pressCoroutine = null;
    }
}
