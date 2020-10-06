using RoR2;
using System.Linq;
using UnityEngine;

namespace ScrapScissors
{
    class ScissorBehaviour : MonoBehaviour
    {
        internal float scrapAmount = 0f;
        private CharacterBody body;
        private static PickupDropTable dropTable;
        internal int itemsGiven = 0, maxItemsGiven;

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
            ScissorsPlugin.activeBehaviours.Add(this);
        }

        private void OnDisable()
        {
            ScissorsPlugin.activeBehaviours.Remove(this);
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

        internal void GiveScrap(bool wasElite, bool wasBoss)
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

            //Because purchaseable drones and turrets are dumb, we have to check if they actually rolled
            float scrapResult = 0;
            if(rolls.Count() > 0)
            {
                scrapResult = rolls.Max();
            }

            if (body.master && !body.master.playerCharacterMasterController && body.master.GetComponent<MinionOwnership>() &&
                body.master.GetComponent<MinionOwnership>().ownerMaster.GetBodyObject().GetComponent<ScissorBehaviour>()) //Minions give scrap to their owner
            {
                body.master.GetComponent<MinionOwnership>().ownerMaster.GetBodyObject().GetComponent<ScissorBehaviour>().scrapAmount += scrapResult;
            }
            else scrapAmount += scrapResult;
        }

        private void GiveItem()
        {
            itemsGiven++;
            PickupIndex index = dropTable.GenerateDrop(Run.instance.treasureRng);
            PickupDropletController.CreatePickupDroplet(index, body.corePosition, Vector3.up * 20f);
        }
    }
}
