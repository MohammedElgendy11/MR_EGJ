## 2024-05-18 - Tactile Button Feedback in VR
**Learning:** In VR environments without physical resistance, UI buttons can feel unresponsive without immediate visual feedback, causing users to double-press.
**Action:** Implement a short (0.1s total), subtle (0.9x) scale down and up animation coroutine on interactive elements (e.g. `KeypadButton` and `HintButton`) triggered on press to provide tactile-like visual feedback. Always cache initial scale in `Awake` and restore it in `OnDisable` to not break custom inspector properties.
