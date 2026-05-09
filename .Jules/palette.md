## 2024-05-17 - Delay Scene Loads for Tactile Feedback
**Learning:** VR UI elements that trigger scene transitions (like Play Again buttons) must complete their visual tactile feedback animation (scaling down/up) before calling `SceneManager.LoadScene()`. If the scene unloads immediately, the user never perceives the feedback, making the interaction feel abrupt and unresponsive.
**Action:** Always use a Coroutine to delay the functional action until the feedback animation completes, and use `Time.unscaledDeltaTime` so it works even if the game is paused.
