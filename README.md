
# iEmoji Project

iEmoji is a fun project that allows users to customize emojis and app icons easily on Windows. By modifying specific files, users can replace emojis with their own designs and change the application icon.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [How to Change Emojis](#how-to-change-emojis)
- [How to Change the App Icon](#how-to-change-the-app-icon)
- [Installation](#installation)
- [Contributing](#contributing)
- [License](#license)

## Overview
iEmoji is designed to let you easily customize emojis within the app. It allows you to edit emoji images stored in specific folders and set a custom app icon through the Visual Studio solution.

## Features
- Change emojis by replacing image files.
- Change the application icon through the project settings.
- Simple and intuitive steps for customization.

## How to Change Emojis
You can easily change the emojis used in the app by following these steps:
1. Navigate to the folder named `imgs` located in either:
   - `bin/debug/imgs`
   - `bin/release/imgs`
2. Replace the emoji image files within this folder with your desired images.
3. Run the `funproject.exe` file located in the same directory as the `imgs` folder, and the new emojis will be displayed in the application.

## How to Change the App Icon
Changing the application icon is straightforward:
1. Open the Visual Studio solution file `iemoji.sln`.
2. In the Solution Explorer, right-click on the `iEmoji` project and select **Properties**.
3. Under the **Application** tab, click on the **Browse** button next to the **Icon** field.
4. Choose the icon file you want to use for the application.

## Installation
1. Clone the repository:
   \`\`\`bash
   git clone https://github.com/your-username/iemoji.git
   \`\`\`
2. Open the solution `iemoji.sln` in Visual Studio.
3. Build the project and run the executable `funproject.exe`.

## Contributing
Contributions are welcome! If you have suggestions or improvements, feel free to submit a pull request or open an issue.

## License
This project is licensed under the MIT License.

---

Developed by Amro Walid Muhammad Khairy.
