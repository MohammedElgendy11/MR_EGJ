## 2024-05-01 - Visual Tactile Feedback for Buttons
**Learning:** In virtual environments (like VR/XR) without physical buttons, UI elements need strong visual feedback to feel "tactile". When buttons transition scenes instantly on click without visual feedback, it feels abrupt and unresponsive.
**Action:** Always implement a brief "press" animation (like a quick scale down and up) and wait for it to complete before triggering irreversible actions like scene transitions. Cache original scale in `Awake` and restore in `OnDisable` to prevent state corruption.
