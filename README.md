# Cuphead Unity Study Project ☕️

This repository contains a study project developed in the **Unity Engine**, with the goal of recreating and analyzing the gameplay mechanics, collision systems, and AI states of the original *Cuphead* game.

---

## ⚠️ Disclaimer / Legal Notice (Important)

This project is **exclusively for educational, non-commercial, and portfolio purposes**.

* **Intellectual Property:** All trademark rights, name, characters, visual art, and soundtrack belong to **Studio MDHR**. This project is not official and has no affiliation with the developer.
* **Purpose:** This code was written as a technical exercise in programming and game design. There is no intention to infringe any copyrights.
* **Distribution:** This repository does not provide the full game and must not be used for profit or piracy.
* **License:** The MIT license applies strictly to .cs files. The image and sound files contained in the /Assets/Sprites folder are the property of Studio MDHR and are included here solely for technical demonstration purposes.

---

## 🎯 Study Goals

The main focus of this implementation was the technical challenge of replicating the fluidity of the original game, focusing on:
* **State Machines (FSM):**  Managing player states (Idle, Run, Jump, Dash, Parry).
* **Boss AI:** Implementation of cyclic attack patterns and phase transitions.
* **Frame-by-Frame Animation:** Synchronizing complex 2D animations with collision logic (Hitboxes).
* **Parallax Effect:** Recreating the classic visual depth of 1930s cartoons.

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Before cloning the project, ensure you have the following installed:

* **Unity Hub:** [Download here](https://unity.com/download)
* **Unity Engine:** Version **6**
* **Git LFS:** Highly recommended for handling large 2D assets and audio files.

### Installation & Setup

1. **Clone the repository**
   Open your terminal and run the following command:
   ```bash
   git clone [https://github.com/your-username/cuphead-clone.git](https://github.com/your-username/cuphead-clone.git)

2. **Add the project to Unity Hub**

   * Open Unity Hub.

   * Click on the Add button (or Open > Add project from disk).

   * Navigate to the folder where you cloned the repository and select it.

3. **Open and Import**

   * Click on the project name within Unity Hub to launch it.

   * Note: The first launch may take several minutes. Unity will automatically reconstruct the Library folder and re-import all assets (Sprites, Audio, and Scripts) to match your local environment.

4. **Select the Initial Scene**

   * Once the editor is open, go to Assets > Scenes.
