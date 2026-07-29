## 2024-07-29 - Added tactile feedback to PlayAgain button
**Learning:** Implementing visual feedback (scaling down and up) for UI interactions in Unity requires using unscaled delta time to ensure smooth animation even if the game is paused.
**Action:** Always verify UI coroutine animations use Time.unscaledDeltaTime for time-independent feedback.
