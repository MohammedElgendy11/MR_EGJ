## 2024-05-02 - Scene Transition UX in VR
**Learning:** Functional actions (like scene transitions) triggered by UI buttons in VR can feel abrupt and lack clear confirmation if executed immediately. Immediate unloads interrupt or prevent visual tactile feedback (like scale animations).
**Action:** Always implement a brief coroutine for visual tactile feedback on VR buttons and delay functional actions (like `SceneManager.LoadScene`) until the feedback animation completes, ensuring the user perceives the interaction before the context changes.
