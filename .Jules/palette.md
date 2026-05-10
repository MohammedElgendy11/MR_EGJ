## 2024-05-10 - Visual Tactile Feedback Deferral
**Learning:** When adding visual tactile feedback animations (like scaling coroutines) to UI elements that trigger scene loads, the functional action (`SceneManager.LoadScene`) must be deferred until the coroutine finishes, otherwise the scene transition happens immediately and the user never sees the feedback.
**Action:** Always place scene loading or destructive actions at the end of the tactile feedback coroutine rather than invoking them immediately.
