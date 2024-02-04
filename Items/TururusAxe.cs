using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TururusMod.Items {

	public class TururusAxe : ModItem {

		public override void SetDefaults() {
			Item.damage = 2500;
			Item.DamageType = DamageClass.Melee;
			Item.width = 59;
			Item.height = 83;
			Item.useTime = 5;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 15;
			Item.value = 1;
			Item.rare = -12;
			Item.UseSound = SoundID.Item1;
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