## 2026-05-15 - VR Scene Transition Buttons
**Learning:** Immediate scene transitions (e.g., `SceneManager.LoadScene`) tied to button clicks often happen so quickly that users miss the physical confirmation of their interaction, feeling abrupt in a VR environment.
**Action:** Always implement a brief tactile visual feedback animation (like scaling down/up) using a Coroutine *before* triggering the scene transition. Use `Time.unscaledDeltaTime` to avoid timescale hangs and ensure the animation is visible before the scene unloads.
