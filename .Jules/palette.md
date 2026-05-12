## 2024-05-12 - VR UI Scene Transition Feedback
**Learning:** In VR interfaces, triggering a scene transition immediately on button press prevents the user from perceiving any visual tactile feedback, making the UI feel unresponsive or broken.
**Action:** Delay the scene transition functional action until after the button's scale down/up visual feedback coroutine has completed.
