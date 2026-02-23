# Palette's Journal

## 2026-02-23 - Coroutine State Reset
**Learning:** When using coroutines for temporary UI feedback (like locking input or changing colors), simply relying on the coroutine to finish is unsafe if the object can be disabled by the user before completion. This can leave the UI in a "stuck" or invalid state.
**Action:** Always implement `OnDisable` to reset state variables (e.g., `isLocked = false`) and restore visual defaults (e.g., `color = defaultColor`) to ensure the component is fresh when re-enabled.
