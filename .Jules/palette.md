## 2024-08-06 - Missing tactile feedback for UI transitions
**Learning:** Users lack confidence when interactive elements (like the Play Again button) instantly trigger terminal actions (like reloading a scene) without visual confirmation.
**Action:** Add tactile feedback coroutines (scale down/up) to UI buttons that trigger terminal actions, ensuring they block spam-clicks and restore state cleanly.
