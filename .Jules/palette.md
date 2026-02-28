## 2024-05-14 - Coroutine Animations for VR Interactables
**Learning:** Coroutine-based UI animations (like tactile feedback scale animations for KeypadButtons) can easily break or stack if not properly managed, especially when objects are disabled/reenabled in VR.
**Action:** When creating animation Coroutines for UI elements, always hold a reference to the Coroutine, stop it before starting a new one (to prevent visual stacking), and rigorously reset state (like `transform.localScale`) and stop Coroutines in `OnDisable` to ensure stability.
