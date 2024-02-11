using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Projectiles.Ranged;
using TururusMod.Rarities;

namespace TururusMod.Items.Ammo {

    public class CannonBullet : ModItem {

        public override void SetDefaults() {
            Item.damage = 23;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 15f;
            Item.value = Item.sellPrice(copper:1);
            Item.value = Item.buyPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<TururusCannonProjectile>();
            Item.shootSpeed = 15f;
            Item.rare = ModContent.RarityType<Flawless>();
            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            CreateRecipe(100)
                .AddIngredient(ItemID.PlatinumBar, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}