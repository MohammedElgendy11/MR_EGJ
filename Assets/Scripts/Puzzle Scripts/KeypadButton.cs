using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string value; 
    public KeypadController keypad;

    public void Press()
    {
        keypad.AddNumber(value);
    }
}
