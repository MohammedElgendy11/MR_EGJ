## 2024-05-18 - Unity UI Button Tactile Feedback
**Learning:** Adding a subtle, unscaled-time scaling coroutine (e.g., shrinking to 0.9x and back) to Unity UI buttons before triggering terminal actions like scene loads significantly improves perceived responsiveness and provides clear visual confirmation of a click, preventing user confusion or spam-clicking.
**Action:** When working on Unity projects, consider adding similar non-blocking tactile coroutines to interactive UI elements that lead to sudden state changes.
