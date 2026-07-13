
## 2024-07-13 - Add tactile feedback to scene transitions
**Learning:** Adding a brief (0.15s) visual scale-down/scale-up tactile feedback animation before a destructive/scene-loading action improves user perception of responsiveness, especially for critical buttons like 'Play Again'. It's important to use `Time.unscaledDeltaTime` so the animation completes even if the game is paused or timescale is modified, and to handle Coroutine cancellation on subsequent clicks to prevent overlap.
**Action:** When creating primary call-to-action buttons in Unity UI that load scenes, wrap the `SceneManager.LoadScene` call in a short feedback coroutine that scales the button down then up.
