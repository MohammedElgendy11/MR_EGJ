## 2026-05-23 - [Tactile Feedback for VR UI Buttons]
**Learning:** Instant scene transitions attached to VR UI buttons can leave users uncertain if their input was registered, resulting in poor perceived responsiveness and potential double-clicking.
**Action:** Implemented a brief visual scale down/up coroutine before scene transitions. Always cache the original scale in Awake and restore in OnDisable to prevent state corruption, and use Time.unscaledDeltaTime for animations to ensure they function regardless of game timescale.
