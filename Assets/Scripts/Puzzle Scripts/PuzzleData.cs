using UnityEngine;

[CreateAssetMenu(menuName = "Puzzle/Puzzle Data")]
public class PuzzleData : ScriptableObject
{
    [TextArea(2, 5)]
    public string question;

    [TextArea(2, 4)]
    public string[] hints = new string[3];

    public string correctAnswer;
    public int baseScore = 1000;
}
