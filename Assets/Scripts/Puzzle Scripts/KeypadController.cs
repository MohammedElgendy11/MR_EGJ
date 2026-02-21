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
    private bool isLocked = false;

    public static event Action OnPuzzleCompleted;

    void Start()
    {
        displayText.text = "----";
        flag = 1;
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
            StartCoroutine(ShowErrorRoutine());
        }
    }

    private IEnumerator ShowErrorRoutine()
    {
        isLocked = true;
        Color originalColor = displayText.color;

        displayText.text = "ERROR";
        displayText.color = Color.red;

        yield return new WaitForSeconds(1f);

        displayText.color = originalColor;
        isLocked = false;
        ClearAll();
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
