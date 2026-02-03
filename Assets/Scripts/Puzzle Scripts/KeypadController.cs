using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI displayText;

    [Header("Password")]
    public string correctPassword = "371";
    public int maxLength = 4;

    string currentInput = "";

    void Start()
    {
        displayText.text = "----";

       //UpdateDisplay();
    }

    // ====== NUMBERS ======
    public void AddNumber(string number)
    {
        if (currentInput.Length >= maxLength)
            return;

        currentInput += number;
        UpdateDisplay();
    }

    // ====== CLEAR ALL ======
    public void ClearAll()
    {
        currentInput = "";
        UpdateDisplay();
    }

    // ====== BACKSPACE ======
    public void RemoveLast()
    {
        if (currentInput.Length == 0)
            return;

        currentInput = currentInput.Substring(0, currentInput.Length - 1);
        UpdateDisplay();
    }

    // ====== SUBMIT ======
    public void Submit()
    {
        if (currentInput == correctPassword)
            Unlock();
        else
            WrongPassword();
    }

    void UpdateDisplay()
    {
        displayText.text = currentInput;
    }

    void Unlock()
    {
        Debug.Log("UNLOCK");
    }

    void WrongPassword()
    {
        Debug.Log("WRONG");
        ClearAll();
    }
}
