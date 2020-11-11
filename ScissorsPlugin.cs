using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using R2API.Utils;
using System.Collections.Generic;

namespace ScrapScissors
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.funkfrog_sipondo.sharesuite", BepInDependency.DependencyFlags.SoftDependency)]
    [R2APISubmoduleDependency(new string[] { "ResourcesAPI", "LanguageAPI", "ItemAPI" })]
    [BepInPlugin(modGuid, modName, modVer)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    public sealed class ScissorsPlugin : BaseUnityPlugin
    {
        private const string modName = "RustyScissors";
        private const string modGuid = "com.RicoValdezio." + modName;
        private const string modVer = "1.7.0";
        internal static ScissorsPlugin instance;
        internal static List<ScissorBehaviour> activeBehaviours;
        internal static bool isShareSuiteActive = false;

        private void Awake()
        {
            foreach (KeyValuePair<string, PluginInfo> keyValuePair in Chainloader.PluginInfos)
            {
                if (keyValuePair.Key == "com.funkfrog_sipondo.sharesuite")
                {
                    BaseUnityPlugin shareSuiteInstance = keyValuePair.Value.Instance;
                    isShareSuiteActive = Reflection.GetFieldValue<ConfigEntry<bool>>(shareSuiteInstance, "ModIsEnabled").Value;
                    break;
                }
            }

            if (instance == null) instance = this;
            activeBehaviours = new List<ScissorBehaviour>();
            ScissorConfig.Init();
            ScissorItem.Init();
        }
    }
}
