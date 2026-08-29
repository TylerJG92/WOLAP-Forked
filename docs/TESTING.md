# ModLoader attempt

Thunderstore plugin-local Newtonsoft test: Vanilla Newtonsoft 9 retained in the game's Managed directory. Newtonsoft 11 placed alongside WOLAP and Archipelago.MultiClient.Net in the Thunderstore profile. WOLAP and its UI load successfully, but attempting to create an Archipelago session throws a TypeLoadException because Newtonsoft.Json.Linq.JToken from Newtonsoft.Json 11.0.0.0 cannot be resolved.

After some research into how BepInEx files work, It would be beneficial to create a patch file instead that would load before the game and inject the file where it needs to go. I'm going to try placing the Newtonsoft.Json.dll file there first before trying to make a patch file to see if that works.
- Solution:
    - BepInEx has a pre-loader patcher system that allows for us to be able to find both the current Newtonsoft.Json.dll within the main games files (v9.0.0.0) and replace it at runtime only to the Newtonsoft.Json.dll file needed for the Archipelago Client (v11.0.0.0), This does **Not** replace the file permanently, instead only replacing at runtime, allowing all base files for WoL to remain untouched or changed. A working pre-loader patch has been created and now resides in `.\patcher\WOLAP.DependencyPatcher\DependencyPatcher.cs`

## r2modman Profile Test

Replicated the working Thunderstore profile layout in r2modman using BepInEx 5.4.23.5.

The dependency patcher successfully replaced West of Loathing's runtime Newtonsoft.Json v9.0.0.0 with Newtonsoft.Json v11.0.0.0. WOLAP loaded normally and successfully connected to an Archipelago server.

The same patcher/plugin layout therefore works under both Thunderstore Mod Manager and r2modman.
- Complete:
    - Verified that the mod loads as intented now and the base game can still be opened in steam withouth the mod loading. On a side note both Thunderstore and r2Modman also did not replace the games Newtonsoft.Json.dll file under its own managed folder as expected, leaving my goal of keeping all base files intact for vanilla gameplay fundimentally complete. 

# 2 files failed to load when expected: 
One earlier run reported Backports and ILHelpers absent at Awake(), while the subsequent controlled run found both loaded from the Thunderstore BepInEx core directory.
One initial run reported MonoMod.Backports and MonoMod.ILHelpers absent during Awake(). Five subsequent launches using the same test could not reproduce this; both assemblies were consistently loaded by the snapshot. Cause unknown. Solution Unknown, No further testing will be concluded unless it becomes a problem.
- Solution:
    - Ignore It, These are lib .dll files and will have varying activation times. With other testing I confirmed the varying activation times and decided that I would rather just leave it alone since it is not my file, but rather it is a file from BepInEx, and as such would rather not go poking around as to why its doing this and instead ignore it unless it becomes an actual problem

# Test seed for AP Connection
https://archipelago.gg/room/blY5GvroSVOIbef6BXJZUw
