## 2024-03-26 - Visual Feedback for VR Buttons
**Learning:** VR UI interactables (like Keypad or Hint buttons) lack inherent haptic or visual confirmation when pressed, leading to user uncertainty and potential double-clicks.
**Action:** Always implement a consistent coroutine-based scale animation (scaling down to 0.9x and back over ~0.1s) for interactive UI elements. Ensure to cache the original scale in `Awake()` and restore it in `OnDisable()` to prevent permanent deformation or conflicts with custom inspector scales.
