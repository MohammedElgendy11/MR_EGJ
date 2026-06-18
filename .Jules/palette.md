## 2024-11-20 - Add tactile feedback to PlayAgain button
**Learning:** Unity UI buttons triggering synchronous scene loads (e.g., `SceneManager.LoadScene`) freeze the main thread, robbing users of immediate visual feedback for their click.
**Action:** When implementing scene transitions attached to buttons, wrap the logic in a coroutine that plays a fast (~0.15s) visual feedback animation (like scaling down/up) before firing the synchronous load, using `Time.unscaledDeltaTime` to ensure the animation plays regardless of the game's time scale.
