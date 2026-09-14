## 2024-05-15 - Visual Feedback for Unity Coroutines
**Learning:** Unity UI elements that perform immediate destructive actions like SceneLoading can create jarring experiences without visual feedback.
**Action:** Always wrap `SceneManager.LoadScene` calls in a coroutine that provides visual feedback (like scaling) and early-return if a transition is already in progress to prevent spam-clicking.
