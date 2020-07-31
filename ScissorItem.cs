using R2API;
using RoR2;
using System.Reflection;
using UnityEngine;

namespace ScrapScissors
{
    internal class ScissorItem
    {
        internal static ItemIndex index;

        internal static void Init()
        {
            AddProvider();
            AddTokens();
            AddItem();
            On.RoR2.CharacterBody.OnInventoryChanged += CharacterBody_OnInventoryChanged;
        }

        private static void AddProvider()
        {
            using (System.IO.Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ScrapScissors.ScissorBundle"))
            {
                AssetBundle bundle = AssetBundle.LoadFromStream(stream);
                AssetBundleResourcesProvider provider = new AssetBundleResourcesProvider("@ScissorBundle", bundle);
                ResourcesAPI.AddProvider(provider);
            }
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
                pickupIconPath = "@ScissorBundle:Assets/Scissor/ScissorIcon.png",
                pickupModelPath = "@ScissorBundle:Assets/Scissor/ScissorPrefab.prefab",
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

        private static void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig(self);
            if (!self.gameObject.GetComponent<ScissorBehaviour>() && self.inventory.GetItemCount(index) != 0)
            {
                self.gameObject.AddComponent<ScissorBehaviour>();
            }
        }
    }
}