# Peacock AutoUpdater

**Peacock AutoUpdater** is an automated updater for Peacock. It automatically checks the official Peacock GitHub repository for new releases and installs updates with minimal user interaction.

> [!WARNING]
> This project is currently in active development. Bugs and incomplete features may exist.

---

## Features

- Detects, downloads and installs new versions of Peacock
- Optional preservation of user data by keeping the following folders (as per the Peacock Wiki article for Updates):
  - `userdata`
  - `contractsessions`
  - `plugins`

---

## Planned / Work in Progress

- Automatic detection of currently installed Peacock version

---

## Command Line Arguments

### `-noDownload`

Disables all GitHub interaction.

- No version checks
- No update downloads
- Intended mainly for development and offline testing

```bash
PeacockAutoUpdater.exe -noDownload
```

### `-newConfig`

Forces regeneration of a fresh configuration file on startup.
- Deletes existing config.json
- Creates a new default configuration file on next launch

```bash
PeacockAutoUpdater.exe -newConfig
```

## AI Usage Disclaimer

No AI-Tools of any kind were used in the creation of any part of this project (Code, Resources, etc.), except for:
- VS2022 IntelliSense Auto-Complete (which is technically AI, because it can offer suggestions)

## License

This project is licensed under the **GNU General Public License v3.0 (GPL-3.0)**. 

### Key Terms & Permissions:
* **Commercial & Private Use:** Permitted. 
* **Modification & Distribution:** Anyone can copy, distribute, and modify this software, provided that they credit the original author and make their modified source code publicly available under the exact same GPL-3.0 license.
* **No Liability/Warranty:** This software is provided as-is without any warranties.

For more details, see the official [GNU GPLv3 License Documentation](https://www.gnu.org/licenses/gpl-3.0.html).