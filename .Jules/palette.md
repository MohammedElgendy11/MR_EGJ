# Palette's Journal

## 2024-05-22 - Missing Error Feedback on Keypad
**Learning:** The VR keypad component provided no feedback for incorrect entries, leading to user confusion about whether the input was registered or why it failed. A debug log "WRONG PASSWORD" is insufficient for end users.
**Action:** Implemented visual feedback (red text "ERROR") and temporary input locking to clearly communicate failure states, following the principle that every interaction should provide immediate, understandable feedback.
