## 2024-07-05 - Tactile Feedback Coroutines
**Learning:** For UI buttons that trigger scene transitions, the functional action (e.g., `SceneManager.LoadScene`) must be executed at the *end* of the visual tactile feedback coroutine rather than immediately, to ensure the user perceives the feedback. Also, using `Time.unscaledDeltaTime` is crucial so animations don't hang if the game timescale is paused.
**Action:** When implementing button tactile feedback, always wrap the scene load inside the coroutine and use `Time.unscaledDeltaTime` for the animation loop.
