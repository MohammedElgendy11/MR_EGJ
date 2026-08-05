## 2026-08-05 - Prevent Button Spamming During Transitions
**Learning:** Adding a transitioning flag to buttons that trigger terminal actions (like loading a new scene) is essential. Without it, spam-clicking can restart tactile animations, delaying the scene load and confusing users.
**Action:** Always include an early return flag (e.g. `isTransitioning`) in UI coroutines that lead to state changes.
