## 2026-04-23 - [VR Button Tactile Feedback]
**Learning:** Users lack confidence when pressing VR UI buttons that trigger scene transitions because the immediate scene freeze/load process cuts off any visual confirmation.
**Action:** For UI buttons that trigger scene transitions (e.g., PlayAgainBtn), ensure the functional action (e.g., SceneManager.LoadScene) is executed at the end of a brief scale down/up coroutine animation, rather than immediately, so the user perceives the tactile feedback before the scene unloads.
