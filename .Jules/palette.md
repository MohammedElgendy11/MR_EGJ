## 2024-06-05 - Delay Scene Transitions for Tactile Feedback
**Learning:** Immediate scene transitions (like LoadScene) cancel out any visual tactile feedback (like scale animations) before the user can perceive it.
**Action:** When implementing button click visual feedback, move the scene transition logic to the end of the feedback coroutine, ensuring the transition only happens after the animation completes.
