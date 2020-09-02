using BepInEx.Configuration;

namespace ScrapScissors
{
    internal class ScissorConfig
    {

        internal static void Init()
        {
            ScissorBehaviour.maxScrap = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Main Settings", "Scrap Threshold"), 100f, new ConfigDescription("Amount of scrap required to roll for an item")).Value;
            ScissorBehaviour.baseScrap = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Main Settings", "Base Scrap Amount"), 3f, new ConfigDescription("Average scrap given by basic monsters")).Value;
            ScissorBehaviour.eliteScalar = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Main Settings", "Elite Scrap Multiplier"), 2f, new ConfigDescription("Scrap multiplier applied to elite monsters")).Value;
            ScissorBehaviour.bossScalar = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Main Settings", "Boss Scrap Multiplier"), 5f, new ConfigDescription("Scrap multiplier applied to elite monsters")).Value;
            ScissorBehaviour.deviation = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Main Settings", "Deviation Percent"), 0.2f, new ConfigDescription("Decimal representation of how much the scrap value can deviate (0.2 is 20%)", new AcceptableValueRange<float>(0f,1f))).Value;
            ScissorBehaviour.softCapCheck = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Item Cap Settings", "Soft Cap Enabled"), true, new ConfigDescription("If enabled, player can only recieve Soft Cap Step * Stacks items per stage", new AcceptableValueList<bool>(true, false))).Value;
            ScissorBehaviour.softCapStep = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Item Cap Settings", "Soft Cap Step"), 2, new ConfigDescription("The number of items per stack a player can recieve per stage if the Soft Cap is enabled")).Value;
            ScissorBehaviour.hardCapCheck = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Item Cap Settings", "Hard Cap Enabled"), false, new ConfigDescription("If enabled, player can only recieve up to the Hard Cap Amount items per stage", new AcceptableValueList<bool>(true, false))).Value;
            ScissorBehaviour.hardItemsGiven = ScissorsPlugin.instance.Config.Bind(new ConfigDefinition("Item Cap Settings", "Hard Cap Amount"), 5, new ConfigDescription("The maximum number of items a player can recieve per stage if the Hard Cap is enabled")).Value;
        }
    }
}