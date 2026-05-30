## 2024-05-30 - VR UI Tactile Feedback
**Learning:** VR UI elements lack physical tactile feedback, making it hard for users to know if an interaction was successful.
**Action:** Implement a brief scale down/up coroutine animation on interaction. Always cache the original scale in `Awake` and restore it in `OnDisable` to prevent state corruption upon interaction interruption. Use `Time.unscaledDeltaTime` to ensure animation runs regardless of timescale.
