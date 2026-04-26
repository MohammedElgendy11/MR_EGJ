## 2026-04-26 - [Visual Tactile Feedback for VR UI]
**Learning:** Adding a brief scale down/up coroutine animation on interaction provides necessary visual tactile feedback for VR UI elements, improving UX without requiring sound or haptics.
**Action:** When implementing VR UI buttons, cache original scale in `Awake`, implement coroutine for scale animation, and restore scale in `OnDisable` to prevent state corruption.
