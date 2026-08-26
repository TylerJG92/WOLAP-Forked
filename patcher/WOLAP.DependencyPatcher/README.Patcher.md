# WOLAP Dependency Patcher

This project contains the BepInEx preloader patcher used by the WOLAP fork to handle runtime dependency loading before the main WOLAP plugin is initialized.

## Project Separation

`WOLAP.DependencyPatcher` is intentionally maintained as a separate C# project from the main `WOLAP` plugin.

The two projects produce separate assemblies:

- `WOLAP.csproj` builds `WOLAP.dll`
- `WOLAP.DependencyPatcher.csproj` builds `WOLAP.DependencyPatcher.dll`

The patcher must remain separate because it is loaded by the BepInEx preloader before normal plugins are initialized. Its source files should not be compiled into `WOLAP.dll`.

The main `WOLAP.csproj` therefore excludes source files contained under the `patcher` directory.

## Current Purpose

The patcher is currently being developed to investigate and resolve the Newtonsoft.Json dependency conflict between West of Loathing and Archipelago.MultiClient.Net.

West of Loathing ships with Newtonsoft.Json 9.0.0.0, while the Archipelago dependency used by WOLAP expects Newtonsoft.Json 11.0.0.0.

The goal is to provide the required dependency at runtime without permanently replacing files in the base West of Loathing installation.