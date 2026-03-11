## 2024-05-15 - Missing physical tactile feedback in VR UIs
**Learning:** In VR interfaces, elements like buttons lack physical resistance. Users struggle to recognize whether a button was successfully pressed when it lacks immediate visual feedback, especially since there are no standard HTML/CSS pseudo-classes like `:active` in Unity VR.
**Action:** Consistently implement micro-animations (e.g., a brief 0.1s scale down to 0.9x and back) triggered by interactions on VR buttons to simulate tactile "give" and confirm the input visually.
