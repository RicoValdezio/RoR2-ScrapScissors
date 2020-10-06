Basic Description
------------
This mod includes one new item: Rusty Scissors which is based loosely on the Rusted Key from RoR2 and the 56-Leaf Clover from RoR1.
When a monster is killed while this is in the inventory, a random amount of "scrap" will be given to the player (this is currently hidden).
When the player reaches 100 scrap, they are given a random item from the Sacrifice loot table.

Base Math Breakdown
------------
- Basic monsters give 3 scrap
- Elites give 2 times the base amount
- Bosses give 5 times the base amount
- These amounts can vary by 20% in either direction
- The above values are all configurable


- Soft Cap Enabled: Up to itemStacks * softCapStep items per stage, softCapStep can be set in config
- Hard Cap Enabled: Up to hardCapAmount items per stage, hardCapAmount can be set in config
- Both Caps Enabled: Up to the lesser of the two caps' items per stage
- No Caps Enabled: No limit to the number of drops per stage


Known Issues/Planned Updates
------------
- A UI element is planned, just need to figure that out

Changelog
------------
1.6.1 - Fixed a bug that was caused by purchased drones and turrets and how Captain's passive works
1.6.0 - Refactored hook registry to allow turrets and drones to give scrap to their owner
1.5.3 - Changed hook to check if player controlled, should prevent odd behaviour with drones/turrets/clones
1.5.2 - Fixed bugs with Engineer and multiplayer that prevented drops in certain cases
1.5.1 - Added NetworkCompatibility helper that I forgot
1.5.0 - Added config option to allow hard cap on drops per stage
1.4.0 - Updated for full release, and added Captain display rule
1.3.0 - Added display rules for all base survivors
1.2.0 - Modified internal math due to feedback, more configuration options
1.1.0 - Fixed the readme, changed the lore, and added a bit of configuration
1.0.0 - Initial Upload

Installation
------------
Place the .dll in Risk of Rain 2\BepInEx\plugins

Contact
------------
If you have issues/suggestions leave them on the github as an issue/suggestion or reach out to Rico#6416 on the modding Discord.
