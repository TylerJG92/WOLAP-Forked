# WOLAP Dependency Patcher

`WOLAP.DependencyPatcher` is a BepInEx preloader patcher used by the WOLAP fork to resolve dependency conflicts before the main WOLAP plugin is initialized.

Its primary purpose is to provide the version of `Newtonsoft.Json` required by Archipelago without permanently modifying the files included with West of Loathing.

## Project Separation

`WOLAP.DependencyPatcher` is intentionally maintained as a separate C# project from the main `WOLAP` plugin.

The two projects produce separate assemblies:

- `WOLAP.csproj` builds `WOLAP.dll`
- `WOLAP.DependencyPatcher.csproj` builds `WOLAP.DependencyPatcher.dll`

The patcher must remain separate because BepInEx loads preloader patchers before normal plugins are initialized.

The patcher's source files therefore should not be compiled into `WOLAP.dll`. The main `WOLAP.csproj` excludes C# source files contained under the `patcher` directory.

## Why the Patcher Is Needed

West of Loathing includes:

- `Newtonsoft.Json` version `9.0.0.0`

The Archipelago client currently used by WOLAP requires:

- `Newtonsoft.Json` version `11.0.0.0`

Loading the game's bundled version causes Archipelago to fail because the required Newtonsoft.Json types are not available.

Previously, WOLAP installation required replacing the game's copy of `Newtonsoft.Json.dll`.

The dependency patcher avoids this by replacing the assembly used by the game at runtime while leaving the original West of Loathing installation untouched.

## How It Works

BepInEx gives the dependency patcher West of Loathing's `Newtonsoft.Json.dll` as a Mono.Cecil `AssemblyDefinition`.

The patcher then:

1. Locates the replacement `Newtonsoft.Json.dll`.
2. Reads the replacement assembly using Mono.Cecil.
3. Replaces BepInEx's target `AssemblyDefinition` with the replacement assembly.
4. Allows the game and WOLAP to continue loading using the required Newtonsoft.Json version.

This replacement occurs only at runtime.

The original file located in:

`West of Loathing_Data/Managed/Newtonsoft.Json.dll`

is not modified.

## Patcher File Layout

`Newtonsoft.Json.dll` must be located in the **same folder** as `WOLAP.DependencyPatcher.dll`.

For example:

```text
BepInEx/
└── patchers/
    └── WOLAP/
        ├── WOLAP.DependencyPatcher.dll
        └── Newtonsoft.Json.dll
```
The folder containing these files does not need to be named `WOLAP`.

The patcher determines the location of its own DLL at runtime and searches for `Newtonsoft.Json.dll` beside it. This allows the patcher to work inside package-specific folders created by mod managers without depending on a particular author, team, or package name.

## Special Instructions for Patcher Updates

When updating the dependency patcher or Archipelago client, verify which version of Newtonsoft.Json.dll is required by the Archipelago client.

For the current WOLAP build, the required replacement is:

Newtonsoft.Json version 11.0.0.0

The required Newtonsoft.Json.dll must be distributed alongside WOLAP.DependencyPatcher.dll as described above.

If Archipelago changes its Newtonsoft.Json dependency in the future, both the packaged replacement DLL and this documentation should be updated accordingly.