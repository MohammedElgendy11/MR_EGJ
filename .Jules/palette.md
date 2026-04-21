## 2024-05-18 - Delayed Destructive Actions for VR Tactile Feedback
**Learning:** Immediate scene transitions (like `SceneManager.LoadScene()`) skip tactile visual feedback (like button presses scaling down/up). This leads to a jarring user experience where interaction feels unacknowledged before everything disappears.
**Action:** Use coroutines to sequence visual feedback before executing destructive actions or scene transitions. Ensure state caching (`originalScale`) and cleanup (`OnDisable`) to handle interrupted animations safely.
