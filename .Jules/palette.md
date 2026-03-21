
## 2024-05-20 - VR Button Tactile/Visual Feedback
**Learning:** In VR games, interactable buttons without immediate visual/haptic feedback leave the user guessing if their press registered, which can lead to double-pressing and frustration. Small scale animations mapped to button presses provide an excellent micro-UX tactile illusion in VR environments.
**Action:** When working on VR interaction components that trigger logic, consider adding a short coroutine-based scale bounce (e.g., scale down to 0.9x and back over 0.1s) and ensure that `transform.localScale` starts from a cached base scale (`Awake()`) rather than resetting to `Vector3.one` to avoid overriding intentional custom scaling in the Editor.
