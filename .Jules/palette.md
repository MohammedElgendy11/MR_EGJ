## 2024-05-18 - Visual Tactile Feedback on VR UI
**Learning:** Immediate hard scene transitions without visual feedback can feel jarring or unresponsive in VR UI. Buttons like `PlayAgainBtn` benefit from explicit visual tactile feedback (e.g., scaling down and up).
**Action:** When creating or updating VR UI interaction buttons that trigger scene changes or heavy operations, implement a quick visual tactile feedback coroutine using `Time.unscaledDeltaTime` (to prevent pauses if TimeScale is 0), and delay the heavy operation until the visual feedback completes.
