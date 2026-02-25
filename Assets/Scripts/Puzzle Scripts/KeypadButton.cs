using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    [Header("Feedback")]
    [SerializeField] private AudioSource buttonSound;

    private Vector3 originalScale;
    private bool isPressed = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void Press()
    {
        if (isPressed) return;

        StartCoroutine(AnimatePress());
        if (buttonSound != null)
        {
            buttonSound.Play();
        }

        keypad.AddNumber(value);
    }

    private IEnumerator AnimatePress()
    {
        isPressed = true;
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
        isPressed = false;
    }

    void OnDisable()
    {
        StopAllCoroutines();
        if (originalScale != Vector3.zero)
        {
            transform.localScale = originalScale;
        }
        isPressed = false;
    }
}
