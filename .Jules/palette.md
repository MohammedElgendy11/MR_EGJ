## 2026-05-29 - Tactile Feedback for Scene Transitions
**Learning:** In VR UI, instant scene transitions on button press are jarring. Functional actions must be delayed to allow visual tactile feedback (like scale animations) to complete first.
**Action:** Implement coroutines to handle button scaling before executing the transition, ensuring the original scale is cached in Awake and restored in OnDisable.
