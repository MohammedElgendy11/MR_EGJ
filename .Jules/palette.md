## 2024-06-25 - Tactile Feedback Coroutine Interruption
**Learning:** When implementing coroutines for UI visual feedback animations (e.g., scaling on click), multiple clicks can spawn overlapping coroutines that corrupt the original visual state.
**Action:** Always store the Coroutine reference, call `StopCoroutine` before starting a new one, and reset the object to its original visual state (cached in `Awake`) in `OnDisable`.
