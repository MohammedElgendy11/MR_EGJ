using UnityEngine;
using System.Collections;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    [Header("UX Feedback")]
    [SerializeField] private AudioSource clickAudio;

    private Vector3 originalScale;
    private Coroutine pressCoroutine;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnDisable()
    {
        if (originalScale != Vector3.zero)
        {
            transform.localScale = originalScale;
        }
    }

    public void Press()
    {
        keypad.AddNumber(value);

        if (clickAudio != null)
        {
            clickAudio.Play();
        }

        if (pressCoroutine != null)
        {
            StopCoroutine(pressCoroutine);
        }
        pressCoroutine = StartCoroutine(AnimatePress());
    }

    private IEnumerator AnimatePress()
    {
        transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = originalScale;
    }
}
