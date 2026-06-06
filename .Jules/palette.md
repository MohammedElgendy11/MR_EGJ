
## 2024-06-06 - VR UI Button Tactile Feedback
**Learning:** VR UI elements, specifically buttons triggering scene changes, lack physical feedback. Immediate scene transitions cut off any opportunity for the user to perceive that they successfully interacted with the element.
**Action:** When creating or updating VR UI buttons, implement a brief visual tactile feedback animation (e.g., scaling down and up) using a coroutine and `Time.unscaledDeltaTime`. Delay functional actions (like `SceneManager.LoadScene`) until this visual feedback has completed.
