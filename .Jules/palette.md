## 2024-10-24 - VR Tactile Feedback for UI Elements
**Learning:** In VR interfaces, simple UI elements without hover states or tactile resistance feel "dead" to users, causing them to repeatedly press buttons thinking inputs weren't registered. Visual displacement on press is crucial.
**Action:** Always implement a brief coroutine-based scale animation (e.g., down to 0.9x over 0.1s total) on interactive UI components, remembering to stop existing coroutines and reset states in OnDisable using an Awake-cached initial scale to preserve custom inspector values.
