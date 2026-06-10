## 2024-06-10 - Visual Tactile Feedback for Scene Transitions
**Learning:** When adding visual tactile feedback to UI elements that trigger scene unloads, the functional action must be delayed until the animation completes. Otherwise, the scene transitions before the user perceives the feedback.
**Action:** Always wait for UI animations (e.g., scale coroutines) to finish before invoking `SceneManager.LoadScene()`.
