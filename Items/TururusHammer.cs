using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TururusMod.Items {

	public class TururusHammer : ModItem {

		public override void SetDefaults() {
			Item.damage = 5000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 71;
			Item.height = 129;
			Item.useTime = 100;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 20;
			Item.value = 10000;
			Item.rare = -12;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddIngredient(ItemID.CooperBar, 2);
            recipe.AddIngredient(ItemID.SilverBar, 2);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddIngredient(ItemID.DemoniteBar, 2);
            recipe.AddIngredient(ItemID.MeteoriteBar, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}