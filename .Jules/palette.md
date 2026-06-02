## 2024-06-02 - Tactile Feedback for VR Scene Transitions
**Learning:** In VR environments, instant scene transitions via UI buttons lack physical tactile feedback, leaving users uncertain if an input was registered before the scene aggressively unloads.
**Action:** Always wrap scene transitions in a brief scale down/up coroutine animation to provide visual confirmation. Crucially, use `Time.unscaledDeltaTime` to ensure the animation plays even if the timescale is paused (e.g., in a game over state), and delay the scene load until the animation completes.
