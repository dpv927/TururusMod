using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Items.Ammo;
using TururusMod.Items.Weapons.Magic;
using TururusMod.Items.Weapons.Melee;
using TururusMod.Items.Weapons.Ranged;
using TururusMod.Projectiles.Ranged;

namespace TururusMod.NPCs {

    [AutoloadHead]
    public class Tururu : ModNPC {

        public const string ShopName = "Shop";
        private static Profiles.StackedNPCProfile NPCProfile;

        public override void SetStaticDefaults() {
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.HatOffsetY[Type] = 4; 
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            AnimationType = 22;
        }

        public override void SetDefaults() {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs) {
            return true;
        }

        public override bool CanChat() {
            return true;
        }

        public override bool UsesPartyHat() {
            return false;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				new FlavorTextBestiaryInfoElement("I can't believe it! It's the real Tururu in person!"),
            });
        }

        public override ITownNPCProfile TownNPCProfile() {
            return NPCProfile;
        }

        public override List<string> SetNPCNameList() {
            return new List<string> {
                "Tururu",
            };
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop) {
            if (firstButton)
                shop = "Shop";
        }

        public override void AddShops() {
            new NPCShop(Type)
                .Add<TururusGenesis>()
                .Add<TururusSword>()
                .Add<TururusYoyo>()
                .Add<TururusCannon>()
                .Add<CannonBullet>()
                .Register();
        }

        public override string GetChat() {
            NPC.FindFirstNPC(ModContent.NPCType<Tururu>());
            switch (Main.rand.Next(5)) {
                case 0: return "Pa que luego digan, no?";
                case 1: return "Mas te vale.";
                case 2: return "Vete que hueles a filete.";
                case 3: return "Referencia a DS1.";
                case 4: return "Dile a 'Paco' que encienda el Fornais.";
                default: return "Eing??";
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ModContent.ProjectileType<TururusCannonProjectile>();
            attackDelay = 1;

            if (NPC.localAI[3] > attackDelay) {
                attackDelay = 12;
            } if (NPC.localAI[3] > attackDelay) {
                attackDelay = 24;
            }
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset) {
            if (!NPC.IsShimmerVariant) {
                int itemType = ModContent.ItemType<TururusCannon>();
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 12;
            } 
            else {
                item = ModContent.Request<Texture2D>(Texture + "_Shimmer_Gun").Value;
                itemFrame = item.Frame();
                horizontalHoldoutOffset = -2;
            }
        }
    }
}
