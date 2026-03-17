## 2025-03-17 - [VR Button Tactile Feedback]
**Learning:** In a VR environment, 2D UI components like buttons often lack sufficient tactile feedback, making it ambiguous whether an interaction was successful.
**Action:** Implement a coroutine-based scale animation on interaction (e.g., scaling down to 0.9x and back over 0.1s) to provide immediate visual/tactile feedback. Ensure `Awake()` caches the initial scale and `OnDisable()` resets it to maintain state consistency across inspector values and coroutine interruptions.
