using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Oculus.Interaction.HandGrab;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI displayText;

    [Header("Password")]
    public string correctPassword = "2114";
    public int maxLength = 4;

    [Header("Settings")]
    [SerializeField] private int maxLength_serialized = 6;

    [Header("References")]
    [SerializeField] private PuzzleManager puzzleManager;

    private string currentInput = "";
    private int flag;
    private Animator mash_anim;

    public static event Action OnPuzzleCompleted;

    private bool isLocked = false;
    private Color defaultColor;

    void Start()
    {
        displayText.text = "----";
        flag = 1;
        if (displayText != null)
            defaultColor = displayText.color;
    }

    void OnDisable()
    {
        isLocked = false;
        currentInput = "";
        if (displayText != null)
        {
            displayText.color = defaultColor;
            displayText.text = "----";
        }
    }

    public void AddNumber(string number)
    {
        if (isLocked) return;

        int usedMaxLength = maxLength_serialized > 0 ? maxLength_serialized : maxLength;

        if (currentInput.Length >= usedMaxLength)
            return;

        currentInput += number;
        UpdateDisplay();
    }

    public void RemoveLast()
    {
        if (isLocked) return;

        if (currentInput.Length == 0)
            return;

        currentInput = currentInput.Substring(0, currentInput.Length - 1);
        UpdateDisplay();
    }

    public void ClearAll()
    {
        if (isLocked) return;

        currentInput = "";
        UpdateDisplay();
    }

    public void Submit()
    {
        if (isLocked) return;

        if (currentInput == correctPassword)
        {
            StartCoroutine(HandleSuccess());
        }
        else
        {
            StartCoroutine(HandleFailure());
        }
    }

    private IEnumerator HandleSuccess()
    {
        isLocked = true;
        if (displayText != null)
        {
            displayText.color = Color.green;
            displayText.text = "ACCESS";
        }

        yield return new WaitForSeconds(0.5f);

        Unlock();
        if (puzzleManager != null)
            puzzleManager.OnPuzzleSolved();

        // Reset
        currentInput = "";
        UpdateDisplay();
        if (displayText != null)
            displayText.color = defaultColor;

        isLocked = false;
    }

    private IEnumerator HandleFailure()
    {
        isLocked = true;
        if (displayText != null)
        {
            displayText.color = Color.red;
            displayText.text = "DENIED";
        }

        yield return new WaitForSeconds(1.0f);

        // Reset
        currentInput = "";
        UpdateDisplay();
        if (displayText != null)
            displayText.color = defaultColor;

        isLocked = false;
    }

    void UpdateDisplay()
    {
        displayText.text = string.IsNullOrEmpty(currentInput) ? "----" : currentInput;
    }

    void Unlock()
    {
        if (flag == 1)
        {
            flag++;
            correctPassword = "41";
            PlayOpenAnimation();
        }
        else if (flag == 2)
        {
            flag++;
            StartCoroutine(PlayTreasureThenSword());
        }
    }

    bool GetAnimator()
    {
        if (mash_anim == null)
        {
            var mashrabya = FindFirstObjectByType<Mashrabya_Tags>();
            if (mashrabya != null)
                mash_anim = mashrabya.GetComponent<Animator>();
        }

        return mash_anim != null;
    }

    void PlayOpenAnimation()
    {
        if (GetAnimator())
            mash_anim.Play("Window_open", 0);
    }

    IEnumerator PlayTreasureThenSword()
    {
        if (!GetAnimator())
            yield break;

        mash_anim.Play("Final_Treasure_Anim", 1);
        yield return new WaitForSeconds(3f);
        mash_anim.Play("FinalSword_anim", 2);

        mash_anim.enabled = false;
        OnPuzzleCompleted?.Invoke();
    }
}
