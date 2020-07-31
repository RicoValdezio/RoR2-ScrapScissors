# Affix Generator

Basic Description
------------
This mod includes one new item: Rusty Scissors which is based loosely on the Rusted Key from RoR2 and the 56-Leaf Clover from RoR1.
When a monster is killed while this is in the inventory, a random amount of "scrap" will be given to the player (this is currently hidden).
When the player reaches 100 scrap, they are given a random item from the Sacrifice loot table.

Math Breakdown
------------
- Basic monsters give 5-10 scrap
- Elite monsters give 10-25 scrap
- Basic bosses give 50-100 scrap
- Elite bosses give 100-200 scrap
- Additional stacks of Rusty Scissors give the player a higher chance of rolling high scrap values

Known Issues/Planned Updates
------------
- Currently no ItemDisplayRules, so the model will not display on survivors
- Might be a bit strong at the moment, will watch for feedback in the Discord
- If balance is not easily solved by community feedback, some configuration is possible
- A UI element is planned, just need to figure that out

Changelog
------------
1.0.0 - Initial Upload

Installation
------------
Place the .dll in Risk of Rain 2\BepInEx\plugins

Contact
------------
If you have issues/suggestions leave them on the github as an issue/suggestion
  or reach out to @Rico#6416 on the modding Discord.
