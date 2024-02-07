using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using TururusMod.Projectiles;

namespace TururusMod.Items {

	public class TururusCannon : ModItem {

        public override void SetDefaults() {
			Item.damage = 1100;
			Item.DamageType = DamageClass.Ranged;	
			Item.width = 59;
			Item.height = 83;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 1;
			Item.rare = -12;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GelBulletProjectile>();
			Item.useAmmo = ModContent.ProjectileType<GelBulletProjectile>();
			Item.shootSpeed = 30f;
			Item.noMelee = true;
		}

		public override void AddRecipes() {
            // 703 704 705 706
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TinBar, 2);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddIngredient(ItemID.TungstenBar, 2);
            recipe.AddIngredient(ItemID.PlatinumBar, 2);        
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 offset = velocity;
			position += offset;
			if (type == ProjectileID.Bullet) 
			{
				type = ModContent.ProjectileType<GelBulletProjectile>();
			}
			for (var i = 0; i < Main.rand.Next(3,4); i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
			return true;
        }

		public override Vector2? HoldoutOffset() {
			Vector2 offset = new Vector2(6, 0);
			return offset;
		}
	}
}