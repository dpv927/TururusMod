using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TururusMod.Items {

	public class TururusStaff : ModItem {

		public override void SetDefaults() {
			Item.damage = 650;
			Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
			Item.width = 59;
			Item.height = 83;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.useStyle = 5;
			Item.knockBack = 2;
			Item.value = 1;
			Item.rare = -12;
			Item.UseSound = SoundID.Item67;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.EnchantedBeam;
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