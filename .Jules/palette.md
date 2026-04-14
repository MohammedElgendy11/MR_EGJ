## 2024-04-14 - Tactile Visual Feedback for VR Interactions
**Learning:** VR UI components without a physical medium often feel unresponsive, leaving users uncertain if an interaction was registered. A brief scale-down animation serves as a strong substitute for tactile feedback.
**Action:** Implement a short scale down/up coroutine (`ProvideTactileFeedback`) on button press for VR UI elements, ensuring to cache and restore the original scale in `Awake` and `OnDisable` to prevent state corruption upon interaction interruption.
