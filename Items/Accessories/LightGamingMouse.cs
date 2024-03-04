﻿using Terraria.ModLoader;
using Terraria;
using TururusMod.Rarities;
using Terraria.ID;

namespace TururusMod.Items.Accessories {

    public class LightGamingMouse : ModItem {

        public override void SetDefaults() {
            Item.width = 22;
            Item.height = 33;
            Item.value = 0;
            Item.rare = ModContent.RarityType<Flawless>();
            Item.value = Item.sellPrice(gold: 6);
            Item.value = Item.buyPrice(gold: 10);
            Item.accessory = true;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.accRunSpeed = 9.8f;
            player.moveSpeed += 0.28f;
            player.iceSkate = true;
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.noFallDmg = true;
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
