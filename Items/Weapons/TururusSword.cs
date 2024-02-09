using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TururusMod.Projectiles;

namespace TururusMod.Items.Weapons
{
    public class TururusSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 3000;
            Item.DamageType = DamageClass.Melee;
            Item.width = 113;
            Item.height = 112;
            Item.useTime = 12;
            Item.useAnimation = 7;
            Item.useStyle = 1;
            Item.knockBack = 30;
            Item.value = 1;
            Item.rare = -12;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<TururusSwordProjectile>();
            Item.shootSpeed = 30f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 5, velocity.Y * 5);
            position += offset;

            type = ModContent.ProjectileType<TururusSwordProjectile>();

            for (var i = 0; i < Main.rand.Next(3, 4); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(25));
                Projectile.NewProjectile(Terraria.Entity.GetSource_NaturalSpawn(), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 0);
            return offset;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TinBar, 2)
                .AddIngredient(ItemID.LeadBar, 2)
                .AddIngredient(ItemID.TungstenBar, 2)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}