## 2024-06-30 - PlayAgain Button Tactile Feedback
**Learning:** For UI buttons that trigger scene transitions, executing functional actions (like SceneManager.LoadScene) immediately without visual feedback makes the UI feel unresponsive or disconnected, especially if scene loading stutters.
**Action:** Implement a short (e.g., ~0.15s) scale down/up tactile feedback coroutine using `Time.unscaledDeltaTime` before loading the scene, ensuring the original scale is cached in `Awake` and restored in `OnDisable` to prevent state corruption.
