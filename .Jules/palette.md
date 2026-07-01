## 2024-05-18 - Tactile feedback for Scene Load
**Learning:** Immediate scene transitions without visual feedback feel abrupt. Adding a short (~150ms) scaling animation using `Time.unscaledDeltaTime` provides tactile confirmation of the action without delaying the user experience significantly.
**Action:** Implement a standard `AnimateAndLoad` coroutine pattern for UI buttons that trigger heavy actions like scene transitions, and ensure original state is cached/restored to prevent state corruption if interrupted.
