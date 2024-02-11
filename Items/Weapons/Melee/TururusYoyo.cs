using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TururusMod.Projectiles.Melee;
using TururusMod.Rarities;

namespace TururusMod.Items.Weapons.Melee {

    public class TururusYoyo : ModItem {
        
        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.damage = 2500;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 3.5f;
            Item.channel = true;
            Item.rare = ModContent.RarityType<FlamingTururu>();
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<TururusYoyoProjectile>();
            Item.shootSpeed = 53f;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.TinBar, 2)
                .AddIngredient(ItemID.LeadBar, 2)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
