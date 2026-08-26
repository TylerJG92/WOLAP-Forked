# ModLoader attempt

Thunderstore plugin-local Newtonsoft test: Vanilla Newtonsoft 9 retained in the game's Managed directory. Newtonsoft 11 placed alongside WOLAP and Archipelago.MultiClient.Net in the Thunderstore profile. WOLAP and its UI load successfully, but attempting to create an Archipelago session throws a TypeLoadException because Newtonsoft.Json.Linq.JToken from Newtonsoft.Json 11.0.0.0 cannot be resolved.

After some reserch into how BipInEx files work, It would be benifitial to create a patch file instead that would load before the game and inject the file where it needs to go. Im going to try placing the Newtonsoft.Json.dll file there first before trying to make a patch file to see if that works.

# 2 files failed to load when expected: 
One earlier run reported Backports and ILHelpers absent at Awake(), while the subsequent controlled run found both loaded from the Thunderstore BepInEx core directory.
One initial run reported MonoMod.Backports and MonoMod.ILHelpers absent during Awake(). Five subsequent launches using the same test could not reproduce this; both assemblies were consistently loaded by the snapshot. Cause unknown. Solution Unknown, No further testing will be concluded unless it becomes a problem.

