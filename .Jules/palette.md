## 2024-05-24 - VR Tactile Feedback Animation
**Learning:** UI elements in VR lack physical feedback; instant scene transitions upon button clicks are disorienting and lack confirmation.
**Action:** Implement a brief scale down/up coroutine animation on interaction using `Time.unscaledDeltaTime` (to handle paused game states), caching original scale in `Awake` and restoring in `OnDisable`. Delay scene transitions until the animation completes.
