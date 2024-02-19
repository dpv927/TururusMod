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
        
        public override void SetDefaults() {
            Item.damage = 40;
            Item.mana = 10;
            Item.width = 61;
            Item.height = 67;
            Item.useTime = Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ModContent.RarityType<Flawless>();
            Item.UseSound = SoundID.Item44;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MagicStar>();
            Item.buffType = ModContent.BuffType<MagicStarBuff>();
            Item.DamageType = DamageClass.Summon;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;
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
