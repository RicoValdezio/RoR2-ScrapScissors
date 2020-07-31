using RoR2;
using System.Linq;
using UnityEngine;

namespace ScrapScissors
{
    class ScissorBehaviour : MonoBehaviour
    {
        private static int scrapAmount = 0;
        private static CharacterBody body;
        private static PickupDropTable dropTable;

        private void OnEnable()
        {
            body = gameObject.GetComponent<CharacterBody>();
            dropTable = Resources.Load<PickupDropTable>("DropTables/dtSacrificeArtifact");
            On.RoR2.GlobalEventManager.OnCharacterDeath += GlobalEventManager_OnCharacterDeath;
        }

        private void LateUpdate()
        {
            if(scrapAmount >= 100)
            {
                scrapAmount -= 100;
                PickupIndex index = dropTable.GenerateDrop(Run.instance.treasureRng);
                PickupDropletController.CreatePickupDroplet(index, body.corePosition, Vector3.up * 20f);
            }
        }

        private void GlobalEventManager_OnCharacterDeath(On.RoR2.GlobalEventManager.orig_OnCharacterDeath orig, GlobalEventManager self, DamageReport damageReport)
        {
            orig(self, damageReport);
            if(damageReport.attackerBody && damageReport.attackerBody == body)
            {
                GiveScrap(damageReport.victimIsElite, damageReport.victimIsBoss);
            }
        }

        private static void GiveScrap(bool wasElite, bool wasBoss)
        {
            bool wasEliteBoss = wasElite && wasBoss;
            int[] rolls = new int[body.inventory.GetItemCount(ScissorItem.index)];
            for (int roll = 0; roll < body.inventory.GetItemCount(ScissorItem.index); roll++)
            {
                int value = 0;
                if (wasEliteBoss)
                {
                    value = Random.Range(100, 200);
                }
                else if (wasBoss)
                {
                    value = Random.Range(50, 100);
                }
                else if (wasElite)
                {
                    value = Random.Range(10, 25);
                }
                else
                {
                    value = Random.Range(5, 10);
                }
                rolls[roll] = value;
            }
            scrapAmount += rolls.Max();
        }
    }
}
