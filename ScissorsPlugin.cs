using BepInEx;
using R2API.Utils;

namespace ScrapScissors
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [R2APISubmoduleDependency(new string[] { "ResourcesAPI", "LanguageAPI", "ItemAPI" })]
    [BepInPlugin(modGuid, modName, modVer)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    public sealed class ScissorsPlugin : BaseUnityPlugin
    {
        private const string modName = "RustyScissors";
        private const string modGuid = "com.RicoValdezio." + modName;
        private const string modVer = "1.5.2";
        internal static ScissorsPlugin instance;

        private void Awake()
        {
            if (instance == null) instance = this;
            ScissorConfig.Init();
            ScissorItem.Init();
        }
    }
}
