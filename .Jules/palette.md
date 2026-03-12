## 2025-03-12 - VR Button Tactile Feedback
**Learning:** VR UI buttons lack tactile feedback like regular UI elements unless explicit feedback is provided; scaling is a quick, intuitive micro-interaction.
**Action:** When creating interactable UI elements for VR, add small scale coroutines (down to 0.9x over 0.1s) and ensure `initialScale` is cached correctly.
