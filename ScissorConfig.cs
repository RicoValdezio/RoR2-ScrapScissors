namespace ScrapScissors
{
    internal class ScissorConfig
    {

        internal static void Init()
        {
            ScissorBehaviour.maxScrap = ScissorsPlugin.instance.Config.Bind("Main Settings", "Scrap Threshold", 100f, "Amount of scrap required to roll for an item").Value;
            ScissorBehaviour.baseScrap = ScissorsPlugin.instance.Config.Bind("Main Settings", "Base Scrap Amount", 3f, "Average scrap given by basic monsters").Value;
            ScissorBehaviour.eliteScalar = ScissorsPlugin.instance.Config.Bind("Main Settings", "Elite Scrap Multiplier", 2f, "Scrap multiplier applied to elite monsters").Value;
            ScissorBehaviour.bossScalar = ScissorsPlugin.instance.Config.Bind("Main Settings", "Boss Scrap Multiplier", 5f, "Scrap multiplier applied to elite monsters").Value;
            ScissorBehaviour.deviation = ScissorsPlugin.instance.Config.Bind("Main Settings", "Deviation Percent", 0.2f, "Decimal representation of how much the scrap value can deviate (0.2 is 20%)").Value;
            ScissorBehaviour.itemCapCheck = ScissorsPlugin.instance.Config.Bind("Main Settings", "Item Cap Enabled", true, "If enabled, player can only recieve stacks x2 items per stage").Value;
        }
    }
}