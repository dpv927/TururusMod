using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TururusMod.Items {

	public class TururusCannon : ModItem {

		public override void SetDefaults() {
			Item.damage = 550;
			Item.DamageType = DamageClass.Magic;
			Item.width = 59;
			Item.height = 83;
			Item.useTime = 5;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 15;
			Item.value = 1;
			Item.rare = -12;
			Item.shoot = 1;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item1;
			Item.shootSpeed = 10.5f;
			Item.noMelee = true;
			Item.autoReuse = true;
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
	}
}