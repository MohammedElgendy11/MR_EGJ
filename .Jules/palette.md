## 2024-04-02 - VR Tactile Feedback Pattern
**Learning:** In VR environments without physical resistance, users often lack confirmation that a button press was registered, leading to repeated presses. A quick (0.1s total) scale down to 0.9x and back provides an effective visual and pseudo-tactile confirmation.
**Action:** Always implement coroutine-based scale animations for interactive VR UI elements, ensuring to cache the original scale in Awake() and reset it in OnDisable() to maintain compatibility with custom Inspector scaling and prevent broken states.
