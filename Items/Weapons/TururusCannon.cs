using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TururusMod.Items.Ammo;
using TururusMod.Projectiles;

namespace TururusMod.Items.Weapons {

    public class TururusCannon : ModItem {

        public override void SetDefaults() {
            Item.width = 59;
            Item.height = 83;
            Item.autoReuse = true;
            Item.damage = 1100;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 4f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Purple;
            Item.shootSpeed = 30f;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.UseSound = SoundID.Item11;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<CannonProjectile>();
            Item.useAmmo = ModContent.ItemType<CannonBullet>();
        }

        public override void AddRecipes() {
            CreateRecipe().
                AddIngredient(ItemID.TinBar, 2)
                .AddIngredient(ItemID.TungstenBar, 2)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
            position += offset;
            return true;
        }

        public override Vector2? HoldoutOffset() {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }
    }
}