## 2024-07-10 - Added Tactile Feedback to Play Again Button
**Learning:** For scene-transitioning UI buttons in Unity, immediate scene loading prevents users from seeing visual click feedback.
**Action:** Always implement a brief (<0.15s) tactile animation coroutine (using Time.unscaledDeltaTime) and defer the LoadScene call until the animation completes. Cache original scale and handle overlapping clicks/OnDisable to prevent state corruption.
