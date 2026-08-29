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