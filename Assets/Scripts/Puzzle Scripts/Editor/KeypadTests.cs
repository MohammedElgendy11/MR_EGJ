using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class KeypadTests
{
    [Test]
    public void KeypadButton_HasFeedbackFields()
    {
        var button = new GameObject().AddComponent<KeypadButton>();

        // Check for fields via reflection since they are private serialized
        var type = typeof(KeypadButton);
        Assert.IsNotNull(type.GetField("pressScale", BindingFlags.NonPublic | BindingFlags.Instance));
        Assert.IsNotNull(type.GetField("animationDuration", BindingFlags.NonPublic | BindingFlags.Instance));

        Object.DestroyImmediate(button.gameObject);
    }

    [Test]
    public void KeypadController_HasIsLockedField()
    {
        var controller = new GameObject().AddComponent<KeypadController>();

        var type = typeof(KeypadController);
        Assert.IsNotNull(type.GetField("isLocked", BindingFlags.NonPublic | BindingFlags.Instance));

        Object.DestroyImmediate(controller.gameObject);
    }
}
