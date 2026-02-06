using UnityEngine;
using TMPro;
using System.Collections;
using Oculus.Interaction.HandGrab;
using System;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI displayText;

    [Header("Password")]
    public string correctPassword = "2814";
    public int maxLength = 4;

    private string currentInput = "";
    private int flag;
    private Animator mash_anim;

    public static event Action OnPuzzleCompleted;
    void Start()
    {
        displayText.text = "----";
        flag = 1;
    }

    #region Buttons
    public void AddNumber(string number)
    {
        if (currentInput.Length >= maxLength)
            return;

        currentInput += number;
        UpdateDisplay();
    }

    public void ClearAll()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void RemoveLast()
    {
        if (currentInput.Length == 0)
            return;

        currentInput = currentInput.Substring(0, currentInput.Length - 1);
        UpdateDisplay();
    }
    public void Submit()
    {
        if (currentInput == correctPassword)
        {
            Unlock();
        }
        else
        {
            WrongPassword();
        }
    }
    #endregion

    void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    void Unlock()
    {
        if (flag == 1)
        {
            Debug.Log("UNLOCK 1 - Mashrabya Window Opening");
            flag++;
            correctPassword = "48";
            PlayOpenAnimation();
            ClearAll();
        }
        else if (flag == 2)
        {
            Debug.Log("UNLOCK 2 - Treasure Box Opening");
            flag++;
            StartCoroutine(PlayTreasureThenSword());
            ClearAll();
        }
        else
        {
            Debug.Log("All puzzles solved!");
            ClearAll();
        }
    }

    void WrongPassword()
    {
        Debug.Log("WRONG PASSWORD");
        ClearAll();
    }

    private bool GetAnimator()
    {
        if (mash_anim == null)
        {
            var mashrabya = FindFirstObjectByType<Mashrabya_Tags>();
            if (mashrabya != null)
            {
                mash_anim = mashrabya.GetComponent<Animator>();
            }
        }

        if (mash_anim == null)
        {
            Debug.LogWarning("Mashrabya Animator not found");
            return false;
        }

        return true;
    }

    void PlayOpenAnimation()
    {
        if (GetAnimator())
        {
            mash_anim.Play("Window_open", 0);
        }
    }

    IEnumerator PlayTreasureThenSword()
    {
        if (!GetAnimator())
            yield break;

        mash_anim.Play("Final_Treasure_Anim", 1);
        Debug.Log("Playing Treasure Animation...");
        yield return new WaitForSeconds(GetAnimationLength("Final_Treasure_Anim", 1));
        PlaySwordBoxAnimation();
        yield return new WaitForSeconds(3f);

        mash_anim.enabled = false;
        OnPuzzleCompleted?.Invoke();

    }

    void PlaySwordBoxAnimation()
    {
        if (GetAnimator())
        {
            mash_anim.Play("FinalSword_anim", 2);
        }
    }

    float GetAnimationLength(string animationName, int layer)
    {
        if (mash_anim == null)
            return 0f;

        AnimatorClipInfo[] clipInfo = mash_anim.GetCurrentAnimatorClipInfo(layer);

        foreach (AnimationClip clip in mash_anim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }

        Debug.LogWarning($"Could not find animation length for {animationName}");
        return 1f;
    }
}