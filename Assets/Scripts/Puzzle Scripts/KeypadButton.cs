using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void Press()
    {
        if (keypad != null)
        {
             keypad.AddNumber(value);
             StopAllCoroutines();
             StartCoroutine(AnimateButton());
        }
    }

    private IEnumerator AnimateButton()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
    }
}
