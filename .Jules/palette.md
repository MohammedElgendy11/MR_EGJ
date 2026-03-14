## 2026-03-14 - VR Tactile Button Feedback
**Learning:** In VR interfaces, interactive UI elements without tactile physical resistance need visual feedback to convey a button press successfully. Instant state changes are jarring; a slight scale animation (e.g., scaling down to 0.9x and back up over 0.1s) provides an intuitive, physically-grounded response.
**Action:** Always implement coroutine-based scale animations for VR buttons, ensuring to cache the original scale in `Awake()` and reset it in `OnDisable()` to prevent custom inspector scales from breaking.
