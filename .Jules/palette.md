## 2024-05-18 - Tactile Feedback for Terminal Actions
**Learning:** Terminal actions like `SceneManager.LoadScene` instantly halt visual feedback unless explicitly managed. Buttons that trigger these require a dedicated visual transition phase before executing the destructive/terminal action to ensure the UI feels responsive.
**Action:** When adding tactile feedback to scene transitions, run the visual scaling coroutine first and execute the scene load at the very end of the sequence.
