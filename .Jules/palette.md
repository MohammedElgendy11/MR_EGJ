
## 2024-05-15 - [Immediate Visual Feedback in VR UI]
**Learning:** VR users lack physical tactile feedback on standard UI buttons (like Keypad or Hint buttons). Without an immediate visual cue that a button was successfully pressed, users may unintentionally double-press or feel the UI is unresponsive. A short, fast (0.1s total) scale down-and-up animation provides the necessary "tactile" visual replacement.
**Action:** When creating interactive UI buttons in VR/spatial environments, always attach a micro-animation (e.g., coroutine-based scale change) that plays immediately upon interaction. Ensure the animation stops and resets properly using cached `Awake` values to avoid breaking custom Inspector scales.
