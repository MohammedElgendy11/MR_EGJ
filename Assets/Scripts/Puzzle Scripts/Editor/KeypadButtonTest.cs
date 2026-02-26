using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class KeypadButtonTest
{
    [Test]
    public void KeypadButton_HasFeedbackFields()
    {
        var type = typeof(KeypadButton);

        Assert.NotNull(type.GetField("audioSource", BindingFlags.NonPublic | BindingFlags.Instance), "audioSource field missing");
        Assert.NotNull(type.GetField("pressSound", BindingFlags.NonPublic | BindingFlags.Instance), "pressSound field missing");
        Assert.NotNull(type.GetField("pressScale", BindingFlags.NonPublic | BindingFlags.Instance), "pressScale field missing");
        Assert.NotNull(type.GetField("animationDuration", BindingFlags.NonPublic | BindingFlags.Instance), "animationDuration field missing");
    }
}
