using R2API;
using RoR2;

namespace Scissors
{
    internal class ScissorItem
    {
        internal static ItemIndex index;

        internal static void Init()
        {
            //LoadAssets();
            AddTokens();
            AddItem();
        }

        private static void AddTokens()
        {
            LanguageAPI.Add("SCISSORS_NAME_TOKEN", "Rusty Scissors");
            LanguageAPI.Add("SCISSORS_PICK_TOKEN", "Converts defeated enemies into useful scrap material.");
            LanguageAPI.Add("SCISSORS_DESC_TOKEN", "Defeated enemies generate scrap that is converted to random items.");
            LanguageAPI.Add("SCISSORS_LORE_TOKEN", "Never underestimate the usefulness of a pair of handy survival scissors.");
        }

        private static void AddItem()
        {
            ItemDef def = new ItemDef
            {
                name = "RustyScissors",
                nameToken = "SCISSORS_NAME_TOKEN",
                pickupToken = "SCISSORS_PICK_TOKEN",
                descriptionToken = "SCISSORS_DESC_TOKEN",
                loreToken = "SCISSORS_LORE_TOKEN",
                tier = ItemTier.Tier1,
                pickupIconPath = null,
                pickupModelPath = null,
                canRemove = true,
                hidden = false,
                tags = new ItemTag[]
                {
                    ItemTag.Utility,
                    ItemTag.OnKillEffect
                }
            };
            ItemDisplayRule[] rules = new ItemDisplayRule[0];
            CustomItem item = new CustomItem(def, rules);
            index = ItemAPI.Add(item);
        }
    }
}