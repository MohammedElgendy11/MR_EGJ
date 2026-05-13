## 2026-05-13 - VR UI Visual Tactile Feedback

**Learning:** When adding visual tactile feedback (like scaling) to UI elements that trigger scene transitions, the scene load must happen at the end of the feedback coroutine, not immediately. Otherwise, the user won't perceive the feedback before the scene unloads.

**Action:** Wrap the scene loading logic in the feedback coroutine and execute it after the animation loop finishes, using `Time.unscaledDeltaTime` to ensure it plays even if time is paused.
