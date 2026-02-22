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

    // Palette: Visual feedback state
    private bool isLocked = false;
    private Color defaultColor;

    public static event Action OnPuzzleCompleted;

    void Start()
    {
        if (displayText != null)
            defaultColor = displayText.color;

        displayText.text = "----";
        flag = 1;
    }

    void OnDisable()
    {
        // Prevent keypad from getting stuck if disabled during error feedback
        if (isLocked)
        {
            isLocked = false;
            if (displayText != null)
                displayText.color = defaultColor;
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
            Unlock();
            if (puzzleManager != null)
                puzzleManager.OnPuzzleSolved();

            ClearAll();
        }
        else
        {
            Debug.Log("WRONG PASSWORD");
            StartCoroutine(ShowErrorFeedback());
        }
    }

    IEnumerator ShowErrorFeedback()
    {
        isLocked = true;

        if (displayText != null)
        {
            displayText.color = Color.red;
            displayText.text = "ERROR";
        }

        yield return new WaitForSeconds(1f);

        if (displayText != null)
        {
            displayText.color = defaultColor;
        }

        // Reset input and unlock
        currentInput = "";
        UpdateDisplay();
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
