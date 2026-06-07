## 2024-05-18 - Visual Tactile Feedback on VR UI
**Learning:** VR UI elements (like buttons that trigger scene loads) can feel unresponsive or abrupt if the action happens instantly without visual feedback, especially since there is no physical touch.
**Action:** Implement a brief scale down/up coroutine animation on interaction to provide visual tactile feedback. Ensure the functional action (e.g., SceneManager.LoadScene) is executed *at the end* of the coroutine, rather than immediately. Always use `Time.unscaledDeltaTime` and restore scale in `OnDisable` to prevent state corruption.
