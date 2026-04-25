## 2024-05-20 - VR Visual Tactile Feedback
**Learning:** In VR interfaces, elements that receive physical interactions without haptic or clear visual cues can feel unresponsive. Relying only on a scene load as the reaction to a button press feels jarring and broken if the scene takes a moment to load.
**Action:** Implemented a micro-animation coroutine that scales the button down slightly (e.g., 0.9f) on press, and restores scale before executing the action, providing necessary visual tactile feedback. Always cache original scale in Awake and restore in OnDisable to prevent state corruption.
