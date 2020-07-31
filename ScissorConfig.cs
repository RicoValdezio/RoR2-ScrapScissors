namespace ScrapScissors
{
    internal class ScissorConfig
    {
        internal static int maxScrap;

        internal static void Init()
        {
            maxScrap = ScissorsPlugin.instance.Config.Bind<int>("Main Settings", "Scrap Threshold", 100, "Amount of scrap required to roll for an item.").Value;
        }
    }
}