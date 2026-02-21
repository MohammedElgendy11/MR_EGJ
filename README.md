# Mashrabya VR: Puzzle & Combat Experience

Welcome to **Mashrabya VR**, an immersive virtual reality experience that challenges your mind and combat skills. Uncover the secrets of the ancient Mashrabya, unlock hidden treasures, and defend yourself against waves of enemies in this Unity-based VR adventure.

## 🎮 Gameplay Overview

Your journey consists of three main phases:

1.  **Solve the Puzzle:** Interact with the mysterious keypad to input the correct code. Clues are hidden around you!
2.  **Unlock the Treasure:** Success reveals the legendary sword hidden within the Mashrabya.
3.  **Survive the Onslaught:** Once the treasure is revealed, the peace is broken. Use your newly acquired sword to fight off waves of enemies that spawn to stop you.

## ✨ Key Features

*   **Interactive Puzzle System:** A functional keypad system for code entry and puzzle solving.
*   **VR Sword Combat:** Physics-based melee combat where you wield a sword to strike down enemies.
*   **Dynamic Enemy Waves:** An enemy spawner system that ramps up the difficulty as you progress.
*   **Immersive Animations:** Detailed animations for the Mashrabya window opening, treasure reveals, and weapon unsheathing.
*   **Oculus Integration:** Built specifically for Oculus Quest and Rift headsets for a seamless VR experience.

## 📂 Project Structure

The project is organized to separate game logic, assets, and scenes. Key scripts can be found in `Assets/Scripts`:

### Core Systems
*   `PuzzleManager.cs`: Manages the state of puzzles and progression.
*   `KeypadController.cs`: Handles user input on the keypad and validates passwords.
*   `ScoreManager.cs`: Tracks player score based on puzzle completion and combat.

### Combat & Enemies
*   `EnemySpawner.cs`: Handles the spawning logic for enemy waves after the puzzle is solved.
*   `EnemyFollow.cs`: Controls enemy AI movement towards the player.
*   `EnemyHealth.cs`: Manages enemy health and death states.
*   `SwordDamage.cs`: Detects collisions between the sword and enemies to deal damage.

### Utility & UI
*   `DisplayLabels.cs`: Manages in-game text and labels.
*   `PlayAgainBtn.cs`: Handles game restart functionality.
*   `Mashrabya_Tags.cs`: Tagging system for the main interactive object.

## 🚀 How to Play

1.  **Launch the Game:** Put on your VR headset and start the application.
2.  **Locate the Keypad:** Find the interactive keypad near the Mashrabya window.
3.  **Enter the Code:** Use your VR controllers to press the buttons. (Hint: Look for clues in the environment!).
4.  **Grab the Sword:** When the window opens and the sword is revealed, reach out and grab it.
5.  **Fight!:** Enemies will appear. Swing your sword to defeat them. Keep an eye on your surroundings!

## 🛠️ Setup & Installation

This project is built with **Unity 6 (6000.3.5f1)**.

### Prerequisites
*   Unity Hub and Unity 6000.3.5f1.
*   Oculus App (for Link/AirLink) or Meta Quest Developer Hub.
*   Visual Studio 2022 (or your preferred IDE).

### Installation
1.  **Clone the Repository:**
    ```bash
    git clone <repository-url>
    ```
2.  **Open in Unity:**
    *   Launch Unity Hub.
    *   Click "Add" and select the cloned project folder.
    *   Open the project (this may take some time to import assets).
3.  **Build for VR:**
    *   Go to `File > Build Settings`.
    *   Select `Android` for Oculus Quest (standalone) or `Windows` for Rift/Link.
    *   Ensure the scene `Game` or `main menu` is added to the build.
    *   Click "Build And Run" with your headset connected.

## 🤝 Credits

*   **Engine:** Unity Technologies
*   **VR SDK:** Oculus Integration (Meta)
*   **Project Lead:** [Your Name/Organization]

---
*Generated for the Mashrabya VR project.*
