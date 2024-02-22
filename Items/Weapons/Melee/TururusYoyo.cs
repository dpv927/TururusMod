using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TururusMod.Projectiles.Melee;
using TururusMod.Rarities;

namespace TururusMod.Items.Weapons.Melee {

    public class TururusYoyo : ModItem {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 26;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.damage = 750;
            Item.knockBack = 8.5f;
            Item.useTime = Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ModContent.RarityType<Flawless>();
            Item.value = Item.sellPrice(copper: 1, silver: 9);
            Item.value = Item.buyPrice(gold: 1);
            Item.shoot = ModContent.ProjectileType<TururusYoyoProjectile>();
            Item.shootSpeed = 16f;
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
