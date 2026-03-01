## 2026-03-01 - Tactile Feedback in VR
**Learning:** VR interfaces lack physical feedback, making simple UI buttons feel unresponsive. Rapidly pressing buttons can cause coroutine conflicts where scaling animations stack and leave UI in an awkward state.
**Action:** Implemented a standardized scale-down coroutine (0.9x over 0.1s) for interactive UI elements. Added `OnDisable` reset logic and coroutine tracking to prevent scale drifting during rapid interactions.
