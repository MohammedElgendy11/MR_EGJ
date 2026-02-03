using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI displayText;

    [Header("Password")]
    public string correctPassword = "2814";
    public int maxLength = 4;
    public int flag;

    string currentInput = "";

    void Start()
    {
        displayText.text = "----";
        flag = 1;
       //UpdateDisplay();
    }
    #region Buttons
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
        if (currentInput == correctPassword )
        {
            Unlock();

        }
        else
            WrongPassword();
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
            Debug.Log("UNLOCK 1 ");
            flag++;
            correctPassword = "48";
            ClearAll();
        }
        else if (flag == 2)
        {
            Debug.Log("UNLOCK 2 ");
        }
    }

    void WrongPassword()
    {
        Debug.Log("WRONG");
        ClearAll();
    }
}
