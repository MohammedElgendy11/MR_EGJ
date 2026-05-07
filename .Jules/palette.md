## 2026-05-07 - Add visual tactile feedback to scene transitions
**Learning:** In VR environments, instantaneous scene transitions on button press deprive users of visual interaction feedback, making the UI feel unresponsive.
**Action:** Added a scale down/up coroutine animation that completes before loading the scene, ensuring the user perceives the tactile feedback.
