# Peacock AutoUpdater

**Peacock AutoUpdater** is an automated updater for [the Peacock Project](https://thepeacockproject.org/). It automatically checks the official Peacock GitHub repository for new releases and installs updates with minimal user interaction.

> [!CAUTION]
> This project is currently in active development. Bugs and incomplete features may exist. The current Logo is also a temporary placeholder.

## Features

- Detects, downloads and installs new versions of Peacock
- Optional preservation of user data by keeping the following folders (as per the Peacock Wiki article about Updates):
  - `userdata`
  - `contractsessions`
  - `plugins`

> [!IMPORTANT]
> Currently the Github API calls use the public API without authentication. Github has a rate limit of 60 requests per hour for unauthenticated requests. If this limit is hit, the updater will not be able to check for new releases until the limit resets.

### Planned / Work in Progress

- Automatic detection of currently installed Peacock version
- Preservation of options.ini

### Command Line Arguments

#### `-noDownload`

Disables all GitHub interaction.

- No version checks
- No update downloads
- Intended mainly for development and offline testing

```bash
PeacockAutoUpdater.exe -noDownload
```

#### `-newConfig`

Forces regeneration of a fresh configuration file on startup.
- Deletes existing config.json
- Creates a new default configuration file

```bash
PeacockAutoUpdater.exe -newConfig
```

### Supported Enviroments
For now the only supported OS is Windows 10/11. A port for Linux is unlikely because WinForms (which this is entirely built on) doesn't support it. But, if I ever dive deeper into a cross-platform UI framework, I might revisit this.

## AI Usage Disclaimer

No AI-Tools of any kind were used in the creation of any part of this project (Code, Resources, etc.), except for:
- VS2022 IntelliSense Auto-Complete (which is technically AI, because it can offer suggestions)

## License

This project is licensed under the **GNU General Public License v3.0 (GPL-3.0)**. 

### Key Terms & Permissions:
The below statements are purely informational and do not constitute a License. They do not grant, restrict or wave any rights. For the full license text, please refer to the LICENSE file included in this repository.
* **Commercial & Private Use:** Permitted. 
* **Modification & Distribution:** Anyone can copy, distribute, and modify this software, provided that they credit the original author and make their modified source code publicly available under the exact same GPL-3.0 license.
* **No Liability/Warranty:** This software is provided as-is without any warranties.

For more details, see the official [GNU GPLv3 License Documentation](https://www.gnu.org/licenses/gpl-3.0.html).