## 2024-05-18 - [Micro-UX VR Animations]
**Learning:** Implementing UI feedback animations (scale down to 0.9x and back) in VR interfaces via Coroutines drastically improves visual/tactile feedback for buttons, but requires managing coroutine states tightly.
**Action:** Ensure coroutines are stopped before restarting and always reset custom states (like `transform.localScale`) in `OnDisable` using values cached in `Awake` to avoid breaking custom Inspector scales.
