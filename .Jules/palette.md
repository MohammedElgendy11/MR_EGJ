## 2024-03-19 - VR Button Tactile Feedback
**Learning:** In VR environments, physical interactions lack physical resistance. Providing immediate visual tactile feedback (like a rapid scale down/up animation) significantly improves the perceived responsiveness of buttons like `KeypadButton` and `HintButton`.
**Action:** When adding coroutine-based animations to UI components, always cache the original scale in `Awake()` and ensure the coroutine stops and scale resets in `OnDisable()` to prevent permanent resizing and broken custom Inspector properties.
