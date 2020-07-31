using BepInEx;
using R2API.Utils;

namespace Scissors
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [R2APISubmoduleDependency(new string[] { "ResourcesAPI", "LanguageAPI", "ItemAPI"})]
    [BepInPlugin(modGuid, modName, modVer)]
    public sealed class ScissorsPlugin : BaseUnityPlugin
    {
        private const string modName = "RustyScissors";
        private const string modGuid = "com.RicoValdezio." + modName;
        private const string modVer = "0.0.1";
        internal static ScissorsPlugin instance;

        private void Awake()
        {
            if (instance == null) instance = this;
            ScissorItem.Init();
        }
    }
}
