
## 2024-07-22 - Visual tactile feedback coroutines for Unity UI buttons
**Learning:** Standard Unity UI buttons often lack intuitive tactile feedback unless heavily customized with Animators. Programmatically implementing a scale-down/scale-up coroutine provides an immediate, generic, and satisfying "bump" effect.
**Action:** When working on interactive UI elements in Unity, implement this tactile scaling feedback pattern (caching original scale in Awake, restoring in OnDisable, using unscaledDeltaTime to avoid timeScale=0 bugs, and halting current coroutines) to improve affordance without needing complex asset modifications.
