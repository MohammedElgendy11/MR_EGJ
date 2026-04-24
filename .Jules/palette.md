## 2026-04-24 - [Visual Tactile Feedback for VR Scene Transitions]
**Learning:** [VR interfaces require immediate visual or tactile feedback upon interaction before initiating a scene transition. Without it, the interface feels unresponsive and scene unloads can feel abrupt or broken.]
**Action:** [Implement a brief scale down/up coroutine animation on interaction, restoring original scale in OnDisable, and delay the functional action (e.g. SceneManager.LoadScene) until the feedback completes.]
