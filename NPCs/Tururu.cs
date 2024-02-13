using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Items.Ammo;
using TururusMod.Items.Weapons.Magic;
using TururusMod.Items.Weapons.Melee;
using TururusMod.Items.Weapons.Ranged;

namespace TururusMod.NPCs {

    [AutoloadHead]
    public class Tururu : ModNPC {

        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.height = 20;
            NPC.width = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 900;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 1.5f;
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = false;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) {
            for (int i = 0; i<255 ;i++) {
                Player player = Main.player[i];
                
                foreach(Item item in player.inventory) {
                    if(item.type == ItemID.WoodenArrow) {
                        return true;
                    }
                }
            }            
            return false;
        }

        public override List<string> SetNPCNameList() {
            return new List<string> { "Tururu" };
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
            if (firstButton) shopName = "Shop";
        }

        public override void AddShops() {
            var shop = new NPCShop(Type, "Shop")
                .Add<TururusSword>()
                .Add<TururusCannon>()
                .Add<TururusGenesis>()
                .Add<CannonBullet>()
                .Add<TururusYoyo>();
            shop.Register();
        }

        public override string GetChat() {
            NPC.FindFirstNPC(ModContent.NPCType<Tururu>());
            var options = new List<string> {
                "Pa que luego digan, no?",
                "Dile al tal 'Paco' que encienda el Fornais.",
                "Vete que hueles a filete.",
                "Persona 5 Dancing in the Moonlight Goty of the year del año",
                "Menuda cochinada"
            };
            return options[Main.rand.Next(options.Count)];
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            damage = 15;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
            cooldown = 5;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) { 
            multiplier = 7f;
        }

        public override void OnKill() {
            Item.NewItem(
                NPC.GetSource_Death(),
                NPC.getRect(),
                ModContent.ItemType<CannonBullet>(),
                25, false, 0, false, false
            );
        }
    }
}