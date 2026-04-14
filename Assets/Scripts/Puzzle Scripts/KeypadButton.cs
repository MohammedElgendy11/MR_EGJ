using UnityEngine;

using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }

    public void Press()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ProvideTactileFeedback());
        }
        keypad.AddNumber(value);
    }

    private IEnumerator ProvideTactileFeedback()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
    }
}
