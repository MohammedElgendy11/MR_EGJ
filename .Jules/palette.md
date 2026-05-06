## 2024-05-24 - Delaying Scene Transitions for Tactile Feedback
**Learning:** In VR and standard UI, scene transitions that occur immediately upon interaction can prevent users from perceiving visual tactile feedback (like a scale down/up button press animation), making the UI feel unresponsive.
**Action:** Execute scene transitions (e.g., `SceneManager.LoadScene`) at the end of the visual tactile feedback coroutine rather than immediately, and use `Time.unscaledDeltaTime` to ensure animations don't hang if timescales change.
