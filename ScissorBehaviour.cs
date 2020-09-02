using RoR2;
using System.Linq;
using UnityEngine;

namespace ScrapScissors
{
    class ScissorBehaviour : MonoBehaviour
    {
        private static float scrapAmount = 0f;
        private static CharacterBody body;
        private static PickupDropTable dropTable;
        private static int itemsGiven = 0, maxItemsGiven;

        internal static float maxScrap, baseScrap, eliteScalar, bossScalar, deviation;
        internal static bool softCapCheck, hardCapCheck;
        internal static int hardItemsGiven, softCapStep;
        private static float baseScrapLow, baseScrapHigh, eliteScrapLow, eliteScrapHigh, bossScrapLow, bossScrapHigh, bigBossScrapLow, bigBossScrapHigh;

        private void OnEnable()
        {
            dropTable = Resources.Load<PickupDropTable>("DropTables/dtSacrificeArtifact");
            body = gameObject.GetComponent<CharacterBody>();
            maxItemsGiven = body.inventory.GetItemCount(ScissorItem.index) * softCapStep;
            CalculateScrapValues();

            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
            On.RoR2.Run.EndStage += Run_EndStage;
        }

        private void LateUpdate()
        {
            //Update the maxItemsGiven based on which cap options are enabled.
            if (hardCapCheck && softCapCheck) maxItemsGiven = Mathf.Min(body.inventory.GetItemCount(ScissorItem.index) * softCapStep, hardItemsGiven);
            else if (!hardCapCheck && softCapCheck) maxItemsGiven = body.inventory.GetItemCount(ScissorItem.index) * softCapStep;
            else if (hardCapCheck && !softCapCheck) maxItemsGiven = hardItemsGiven;
            else maxItemsGiven = int.MaxValue;

            if (scrapAmount >= maxScrap)
            {
                scrapAmount -= maxScrap;
                if (itemsGiven < maxItemsGiven) GiveItem();
            }
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig(self, damageReport);
            if (damageReport.attackerBody && damageReport.attackerBody == body) GiveScrap(damageReport.victimIsElite, damageReport.victimIsBoss);
        }

        private void Run_EndStage(On.RoR2.Run.orig_EndStage orig, Run self)
        {
            orig(self);
            itemsGiven = 0;
        }

        private static void CalculateScrapValues()
        {
            baseScrapLow = baseScrap * (1 - deviation);
            baseScrapHigh = baseScrap * (1 + deviation);
            eliteScrapLow = baseScrap * eliteScalar * (1 - deviation);
            eliteScrapHigh = baseScrap * eliteScalar * (1 + deviation);
            bossScrapLow = baseScrap * bossScalar * (1 - deviation);
            bossScrapHigh = baseScrap * bossScalar * (1 + deviation);
            bigBossScrapLow = baseScrap * eliteScalar * bossScalar * (1 - deviation);
            bigBossScrapHigh = baseScrap * eliteScalar * bossScalar * (1 + deviation);
        }

        private static void GiveScrap(bool wasElite, bool wasBoss)
        {
            bool wasEliteBoss = wasElite && wasBoss;
            float[] rolls = new float[body.inventory.GetItemCount(ScissorItem.index)];
            for (int roll = 0; roll < body.inventory.GetItemCount(ScissorItem.index); roll++)
            {
                float value;
                if (wasEliteBoss) value = Random.Range(bigBossScrapLow, bigBossScrapHigh);
                else if (wasBoss) value = Random.Range(bossScrapLow, bossScrapHigh);
                else if (wasElite) value = Random.Range(eliteScrapLow, eliteScrapHigh);
                else value = Random.Range(baseScrapLow, baseScrapHigh);
                rolls[roll] = value;
            }
            scrapAmount += rolls.Max();
        }

        private static void GiveItem()
        {
            itemsGiven++;
            PickupIndex index = dropTable.GenerateDrop(Run.instance.treasureRng);
            PickupDropletController.CreatePickupDroplet(index, body.corePosition, Vector3.up * 20f);
        }
    }
}
