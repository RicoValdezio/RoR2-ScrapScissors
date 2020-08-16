using R2API;
using RoR2;
using System;
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
            string longLore = "Order: Pair of Regulation Emergency Scissors" + Environment.NewLine +
                              "Tracking Number: 15******" + Environment.NewLine +
                              "Estimated Delivery: March 27, 2559" + Environment.NewLine +
                              "Shipping Method: Standard" + Environment.NewLine +
                              "Shipping Address: Hämeentie 135 A, P.O. Box 130, Helsinki, Finland" + Environment.NewLine +
                              "Shipping Notes:" + Environment.NewLine + Environment.NewLine +
                              "I have no idea why you would even need this particular model, scissors as a whole were made completely irrelevant when that fancy new laser-tech was invented, but I'll leave you to your wild fantasies of reviving the great Art of Scissoring." + Environment.NewLine + Environment.NewLine +
                              "Since you're so gun-ho about this pair, I might as well let you know that it's a relic of the Great War, some ancient conflict on Earth. Anyways, these belong to a medic with a pretty extraordinary track record. Maybe it'll bring you the same luck as it brought him.";
            LanguageAPI.Add("SCISSORS_LORE_TOKEN", longLore);
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

            GameObject followerPrefab = Resources.Load<GameObject>("@ScissorBundle:Assets/Scissor/ScissorPrefab.prefab");
            Vector3 generalScale = new Vector3(0.05f, 0.05f, 0.05f);
            ItemDisplayRuleDict rules = new ItemDisplayRuleDict(new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.22f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlHuntress", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.22f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlToolbot", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "LowerArmR",
                    localPos = new Vector3(-2f, 6f, 0f),
                    localAngles = new Vector3(45f, -90f, 0f),
                    localScale = generalScale * 10
                }
            });
            rules.Add("mdlEngi", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.25f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlMage", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.21f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlMerc", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.22f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlTreebot", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "WeaponPlatform",
                    localPos = new Vector3(0.2f, 0.05f, 0.2f),
                    localAngles = new Vector3(-45f, 0f, 0f),
                    localScale = generalScale * 2
                }
            });
            rules.Add("mdlLoader", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.22f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
            });
            rules.Add("mdlCroco", new ItemDisplayRule[]
            {
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Hip",
                    localPos = new Vector3(-2.2f, 0f, 0f),
                    localAngles = new Vector3(-10f, -0.05f, 0f),
                    localScale = generalScale * 10
                }
            });
            rules.Add("mdlCaptain", new ItemDisplayRule[]
{
                new ItemDisplayRule
                {
                    ruleType = ItemDisplayRuleType.ParentedPrefab,
                    followerPrefab = followerPrefab,
                    childName = "Pelvis",
                    localPos = new Vector3(-0.22f, 0f, 0f),
                    localAngles = new Vector3(0f, -0.05f, 0f),
                    localScale = generalScale
                }
});

            CustomItem item = new CustomItem(def, rules);
            index = ItemAPI.Add(item);
        }

        private static void CharacterBody_OnInventoryChanged(On.RoR2.CharacterBody.orig_OnInventoryChanged orig, CharacterBody self)
        {
            orig(self);
            if (!self.gameObject.GetComponent<ScissorBehaviour>() && self.inventory.GetItemCount(index) != 0) self.gameObject.AddComponent<ScissorBehaviour>();
        }
    }
}