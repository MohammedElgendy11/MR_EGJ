## 2024-04-11 - Tactile VR Feedback
**Learning:** VR interactions lack physical resistance. Adding subtle scale animations (0.9x over 0.1s) when interacting with UI elements (like buttons) significantly improves the intuitive "feel" of interactions, compensating for the lack of tactile feedback.
**Action:** Always implement scale down/up coroutines for interactive UI components to provide visual feedback for interactions.
