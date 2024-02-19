using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TururusMod.Rarities;
using TururusMod.Projectiles.Summon;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TururusMod.Buffs;

namespace TururusMod.Items.Weapons.Summon {

    public class TururusStaff : ModItem {

        private int totalProjectiles;

        public override void SetDefaults() {
            Item.width = 61;
            Item.height = 67;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item44;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 10;
            Item.damage = 275;
            Item.knockBack = 2f;
            Item.autoReuse = true;
            Item.useTime = Item.useAnimation = 15;
            Item.shoot = ModContent.ProjectileType<MagicStar>();
            Item.shootSpeed = 13f;
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ModContent.RarityType<Flawless>();
            totalProjectiles = 0;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (player.altFunctionUse != 2) {
                int p = Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, type, damage, knockback, player.whoAmI);
                if (Main.projectile.IndexInRange(p))
                    Main.projectile[p].originalDamage = Item.damage;
            }

            float angleMax = MathHelper.ToRadians(45f);
            if (totalProjectiles == 1)
                angleMax = 0f;
            
            float index = 1f;
            if (player.ownedProjectileCounts[Item.shoot] > 8) {
                angleMax += MathHelper.ToRadians((player.ownedProjectileCounts[Item.shoot] - 8) * 2.5f);
            }

            angleMax = angleMax > MathHelper.ToRadians(105f) ? MathHelper.ToRadians(105f) : angleMax; // More intuative than using a min function
            for (int i = 0; i < Main.projectile.Length; i++) {
                if (Main.projectile[i].active && Main.projectile[i].type == type && Main.projectile[i].owner == player.whoAmI) {
                    Main.projectile[i].ai[1] = (index / totalProjectiles) * angleMax - angleMax / 2f;
                    Main.projectile[i].netUpdate = true;
                    index++;
                }
            }
            totalProjectiles++;
            return false;
        }

        public override void AddRecipes() {
            CreateRecipe().
                AddIngredient(ItemID.TinBar, 2)
                .AddIngredient(ItemID.TungstenBar, 2)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
