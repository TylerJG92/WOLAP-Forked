# WOLAP
A client mod for [West of Loathing](https://store.steampowered.com/app/597220/West_of_Loathing/), integrating it with the [Archipelago multiworld multi-game randomizer system](https://archipelago.gg/).

## WORK IN PROGRESS
This mod is very much incomplete, but it *should* be playable. Bug reports and all kinds of feedback are welcome, and should be directed to the West of Loathing thread in the `#future-game-design` channel on the [Archipelago Discord server](https://discord.gg/8Z65BR2).

## What does this mod do?
The majority of the game's unique items and pickup locations have been randomized.  Currently, most non-unique loot and combat drops, unlimited shop items, and Foragin' plants are not included in the randomization.

The following extra Archipelago options have been implemented to configure the randomization:

#### Archipelago Options
- Enable Gun Manor DLC
  - Name in YAML file: `dlc_enabled`
  - This requires you to own the "Reckonin' at Gun Manor" DLC.  Disabling this while owning the DLC won't prevent you from accessing that content, it just won't include the DLC items and check locations in the randomization pool.
  - This is enabled by default
- Randomize Gun Manor Coach
  - Name in YAML file: `randomize_ghost_coach`
  - This randomizes the coach needed to access Gun Manor into the item pool
  - This is enabled by default, and has no effect unless the DLC is also enabled
- Randomize Goblintongue
  - Name in YAML file: `randomize_goblintongue`
  - This randomizes the ability to speak Goblintongue into the item pool
  - This is enabled by default.  If this is disabled, you will be able to speak Goblintongue from the start of the game.
- Unbreakable Tools
  - Name in YAML file: `unbreakable_tools`
  - This removes the possibility of breaking or using up some important tools - shovel, pickaxe, El Vibrato headband - so you don't need to buy a replacement.
  - This is disabled by default.  Once you receive one of these tools from the item pool, you'll then be able to purchase that tool infinitely from Dirtwater Mercantile.
- Start Inventory From Pool
  - Name in YAML file: `start_inventory_from_pool`
  - This allows you to specify items you will start with that then *won't* be included in the item pool -- as opposed to `start_inventory`, which lets you start with copies of items from the pool

In addition to the basic randomization, this mod makes various changes to the game's logic and mechanics to try to make it work better with Archipelago.  A full list of these changes can be found in the [docs](./docs/changelist.md).

## AI Usage Disclosure
* WOLAP is **not** vibe-coded
* WOLAP does **not** contain AI art
This mod uses AI very minimally, Useage is as follows:
- Xylen:
  - In response to being asked on 8/4/26 if they used AI for the ap world: "Nope. In the interest of full, 100% honest disclosure, I used chatgpt exactly twice through development to try asking it about a couple of weird bugs that had me stuck. It basically just confirmed for me both times that the code I was looking at was fine so I went and manually found the bug elsewhere. None of the code (in the main games mod) is AI-generated" (https://discord.com/channels/731205301247803413/1273856413327822950/1534239231168479242)
- TylerJG92:
  - I am very new to coding and used ChatGPT as a tutor and guide **ONLY** and will continue with that in the main games code until I am comfortable enough to no longer need it as a tutor.
    - Utilizing ChatGPT as a tutor and guide means I did not allow it to generate any code for me, All it ever did was explain steps I might take in troubleshooting, explain coding concepts and spesifics of how C# works together so I could grow to understand how this coding language works
  - I did use ChatGPT to generate some code **outside** of the games mod for an internal folder only.
    - Most of the code writen under `.\ModManager_Packager` is written by me, but I was under a self imposed time crunch and needed to complete the project. Within `build-package.ps1` there is generated code and looking back at it now there is a large chunk of it that is ai generated. I will be removing and re-writing it over the coming weeks in my own way instead of utilizing the generated code. Mainly as a means to learn about the concepts it used that I had not learned. As for architectural design, folder layout, ect. Those were all my ideas and I was very slowly working toward the same type of code myself.
      - This folder `.\ModManager_Packager` is used only to gather all the necessary files needed to package the .Zip folder for upload to Thunderstore. This Folder has nothing to do with the code that is run while playing the games mod.
    - Within the `.\patcher\WOLAP.DependencyPatcher` Almost all of the code within is hand written by me. There is a part where I allowed ChatGPT to remove all my testing loggers in `DependencyPatcher.cs` and instructed it to not remove or change any of the other code I put in. I reviewed it thoroughly for any possible changes it made to the code as well, and it kept it as I wished, only removing the loggers.
      - This folder `.\patcher\WOLAP.DependencyPatcher` is to create a BepInEx preloader patcher file that then gets used by BepInEx to replace the vanilla games `Newtonsoft.Json.dll` file in runtime with the Archipelago.MultiClient.Net.dll's dependent `Newtonsoft.Json.dll` to allow the mod to run properly. This patcher file does not affect the the gameplay of the mod, except to steamline installation.