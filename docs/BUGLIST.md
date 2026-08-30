# BugList
This is a place I can put bugs that I encounter and their solutions of how I fixed them later. A seperate `Issues` List is being kept in TylerJG92's Forked Repository [Here](https://github.com/TylerJG92/WOLAP-Forked/issues)

## Discord reported bugs
This is bugs that while I may have encountered myself, were reported by others on discord



## Testing bugs I encounter
This is where I put the bugs that only I have encountered.

- **Compressed Websocket Connections** This bug/error was noticed when I was testing the new Thunderstore mod that was posted. In the AP room im using for testing This error comes up in its logs but not under BepInEx's logs `[2026-08-29 17:09:52,731]: Notice (Player Tyler-WoL in team 1): Warning: your client does not support compressed websocket connections! It may stop working in the future. If you are a player, please report this to the client's developer.`
    - Further Testing is required, suggest manually installing the mod instead and seeing it that log still persists.
        - Xylen indicated to me that this is a potential issue that has existed from before, from [this message](https://discord.com/channels/731205301247803413/740728420844961799/1436458514183753869) on the AP discord, where the .apworld just needs to be built with the new launcher method and commit the archipelago.json manifest. Will look at doing this myself if Xylen dosent get to it.