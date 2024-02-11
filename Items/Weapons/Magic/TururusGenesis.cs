using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TururusMod.Projectiles.Magic;
using TururusMod.Rarities;

namespace TururusMod.Items.Weapons.Magic {

    public class TururusGenesis : ModItem {

        public override void SetDefaults() {
            Item.width = 76;
            Item.height = 63;
            Item.autoReuse = true;
            Item.damage = 250;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8f;
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.UseSound = SoundID.NPCDeath60;
            Item.rare = ModContent.RarityType<FlamingTururu>();
            Item.shootSpeed = 8f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<TururusGenesisProjectile>();
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
            for (int i = 0; i < 5; i++) {
                Vector2 ringVelocity = (MathHelper.TwoPi * i / 5f + velocity.ToRotation()).ToRotationVector2() * velocity.Length() * 0.5f;
                Projectile.NewProjectile(source, position, ringVelocity, type, damage, knockback, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}