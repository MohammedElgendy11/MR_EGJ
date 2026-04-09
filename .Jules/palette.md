## 2024-04-09 - [VR UI Press Feedback]
**Learning:** In VR interfaces, immediate visual/tactile feedback is crucial for interactive elements since physical touch is absent. Hardcoding Vector3.one for scale resets breaks custom Inspector dimensions, and failing to clean up state on disable causes visual glitches.
**Action:** Implement coroutine-based scale animations caching the initial scale in Awake(), ensure safe startup checking activeInHierarchy, and reset state in OnDisable().
