
## 2024-04-19 - Safe UI Animations in Unity
**Learning:** Coroutine-based UI animations in Unity (like scale changes on click) can permanently corrupt state if the GameObject is disabled mid-animation.
**Action:** Always cache the original transform state in `Awake()`, check `gameObject.activeInHierarchy` before starting coroutines, and restore the cached state in `OnDisable()`.
