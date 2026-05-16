## 2024-05-16 - Tactile Visual Feedback for Scene Transitions
**Learning:** VR UI buttons that trigger immediate functional actions like scene transitions without visual feedback feel unresponsive and lack tactile confirmation, causing user uncertainty.
**Action:** Implement a short (0.1s - 0.2s) scale down/up coroutine using `Time.unscaledDeltaTime` (to prevent timescale hangs) to visually confirm interactions, and delay the functional scene transition until the coroutine completes.
