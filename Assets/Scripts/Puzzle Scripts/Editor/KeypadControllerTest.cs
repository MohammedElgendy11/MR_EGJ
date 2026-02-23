using NUnit.Framework;
using UnityEngine;
using TMPro;

public class KeypadControllerTest
{
    [Test]
    public void AddNumber_AddsToDisplay()
    {
        // Arrange
        var go = new GameObject();
        var keypad = go.AddComponent<KeypadController>();
        var textMesh = go.AddComponent<TextMeshProUGUI>();
        keypad.displayText = textMesh;

        // Act
        keypad.AddNumber("1");

        // Assert
        Assert.AreEqual("1", textMesh.text);
    }

    [Test]
    public void RemoveLast_RemovesFromDisplay()
    {
        // Arrange
        var go = new GameObject();
        var keypad = go.AddComponent<KeypadController>();
        var textMesh = go.AddComponent<TextMeshProUGUI>();
        keypad.displayText = textMesh;
        keypad.AddNumber("1");
        keypad.AddNumber("2");

        // Act
        keypad.RemoveLast();

        // Assert
        Assert.AreEqual("1", textMesh.text);
    }

    [Test]
    public void ClearAll_ResetsDisplay()
    {
        // Arrange
        var go = new GameObject();
        var keypad = go.AddComponent<KeypadController>();
        var textMesh = go.AddComponent<TextMeshProUGUI>();
        keypad.displayText = textMesh;
        keypad.AddNumber("1");

        // Act
        keypad.ClearAll();

        // Assert
        Assert.AreEqual("----", textMesh.text);
    }
}
