using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Projectiles;

namespace TururusMod.Items.Ammo 
{
    public class CannonBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.value = Item.sellPrice(1, 0, 1, 0);
            Item.shoot = ModContent.ProjectileType<CannonProjectile>();
            Item.shootSpeed = 16f;
            Item.rare = ItemRarityID.Purple;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}