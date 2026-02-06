using UnityEngine;

[CreateAssetMenu(menuName = "Puzzle/Puzzle Data")]
public class PuzzleData : ScriptableObject
{
    [TextArea]
    public string question;

    public string correctAnswer;

    public string[] hints;

    public int baseScore = 1000;
}
