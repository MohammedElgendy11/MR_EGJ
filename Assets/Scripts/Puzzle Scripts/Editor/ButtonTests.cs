using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class ButtonTests
{
    private GameObject keypadButtonGo;
    private KeypadButton keypadButton;
    private GameObject hintButtonGo;
    private HintButton hintButton;

    [SetUp]
    public void SetUp()
    {
        keypadButtonGo = new GameObject();
        keypadButton = keypadButtonGo.AddComponent<KeypadButton>();
        keypadButton.keypad = new GameObject().AddComponent<KeypadController>(); // Mock keypad

        hintButtonGo = new GameObject();
        hintButton = hintButtonGo.AddComponent<HintButton>();

        // Mock required components for HintButton using reflection
        var puzzleUIGo = new GameObject();
        var puzzleUI = puzzleUIGo.AddComponent<PuzzleUIController>();
        typeof(HintButton).GetField("puzzleUI", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(hintButton, puzzleUI);

        var scoreManagerGo = new GameObject();
        var scoreManager = scoreManagerGo.AddComponent<ScoreManager>();
        typeof(HintButton).GetField("scoreManager", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(hintButton, scoreManager);

        // Initialize Awake state via reflection
        typeof(KeypadButton).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(keypadButton, null);
        typeof(HintButton).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(hintButton, null);
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.DestroyImmediate(keypadButtonGo);
        UnityEngine.Object.DestroyImmediate(hintButtonGo);
    }

    [Test]
    public void KeypadButton_Press_TriggersFeedbackCoroutine()
    {
        // Act
        keypadButton.Press();

        // Since we are using a shim, StartCoroutine is called on the shim.
        // We can check if it completed without throwing, and if we manually invoke the coroutine, we can check the effect.
        var coroutineMethod = typeof(KeypadButton).GetMethod("ProvideTactileFeedback", BindingFlags.NonPublic | BindingFlags.Instance);
        var enumerator = (System.Collections.IEnumerator)coroutineMethod.Invoke(keypadButton, null);

        // Advance to first yield
        enumerator.MoveNext();

        // Assert: Scale should be 0.9
        Assert.AreEqual(0.9f, keypadButton.transform.localScale.x, 0.001f);
    }

    [Test]
    public void HintButton_Press_TriggersFeedbackCoroutine()
    {
        // Act
        hintButton.OnHintPressed();

        var coroutineMethod = typeof(HintButton).GetMethod("ProvideTactileFeedback", BindingFlags.NonPublic | BindingFlags.Instance);
        var enumerator = (System.Collections.IEnumerator)coroutineMethod.Invoke(hintButton, null);

        // Advance to first yield
        enumerator.MoveNext();

        // Assert: Scale should be 0.9
        Assert.AreEqual(0.9f, hintButton.transform.localScale.x, 0.001f);
    }

    [Test]
    public void KeypadButton_OnDisable_RestoresScale()
    {
        // Arrange
        keypadButton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Act
        typeof(KeypadButton).GetMethod("OnDisable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(keypadButton, null);

        // Assert: Scale should be restored to 1 (the value from Awake)
        Assert.AreEqual(1f, keypadButton.transform.localScale.x, 0.001f);
    }

    [Test]
    public void HintButton_OnDisable_RestoresScale()
    {
        // Arrange
        hintButton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Act
        typeof(HintButton).GetMethod("OnDisable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(hintButton, null);

        // Assert: Scale should be restored to 1 (the value from Awake)
        Assert.AreEqual(1f, hintButton.transform.localScale.x, 0.001f);
    }
}
