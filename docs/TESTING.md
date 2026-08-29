# Testing Documentation
This documentation is meant to be utilized as a "find a problem while coding --> document the issue --> research the issue --> find the solution to the issue and post it here". It is mainly for us to be able to say in the future "I have encounter this issue before, how did it solve it?" and be able to look at this document for a possible solution.
This document May also contain other Non Code Errors and their solutions, but also additional testing that is done outside the gameplay that leads to creating code for a solution.
This documentation may also overlap with other documentation within `BUGLIST.md` as that document will be mainly used to Document Bugs that exist during actual gameplay and game testing.

## ModLoader attempts

### Thunderstore Profile Test 8/22/26
While trying to get my Thunderstore test profile to load the .dlls needed for mod installation by placing the .dll files given from the v0.2.3 release of WOLAP, I was given an "expected" error that the Newtonsoft.Json.dll wasnt loaded correctly. I had placed it alongside the WOLAP.dll and Archipelago.MultiClient.Net.dll in BepInEx's plugins folder, and while everything else loaded to allow for the custom UI to load, once connection was attempted with an archipelago room, It froze the game and threw the error `TypeLoadException because Newtonsoft.Json.Linq.JToken from Newtonsoft.Json 11.0.0.0 cannot be resolved`
- After some research into how BepInEx folders/files work, It would be beneficial to create a patch file instead that would load before the game and inject the file where it needs to go. I'm going to try placing the Newtonsoft.Json.dll file there first before trying to make a patch file to see if that works.
    - **Solution**:
        - BepInEx has a pre-loader patcher system that allows for us to be able to find both the current Newtonsoft.Json.dll within the main games files and replace it at runtime only to the Newtonsoft.Json.dll file needed for the Archipelago Client, This does **Not** replace the file permanently, instead only replacing at runtime, allowing all base files for WoL to remain untouched or changed. A working pre-loader patch has been created and now resides in `.\patcher\WOLAP.DependencyPatcher\DependencyPatcher.cs`

### 2 files load at strange times 8/25/26
One initial run reported `MonoMod.Backports` and `MonoMod.ILHelpers` absent during Awake(). Five subsequent launches using the same test could not reproduce this; both assemblies were consistently loaded by the snapshot.
- **Solution**:
    - <u>Ignore It</u>, These are lib .dll files and will have varying activation times. No further testing required.