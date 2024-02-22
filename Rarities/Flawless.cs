using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TururusMod.Rarities {

    public class Flawless : ModRarity {

        private static int index = 0;
        private static readonly Color[] colors = {
            new Color(001, 245, 254),
            new Color(089, 249, 254),
            new Color(103, 249, 254),
            new Color(128, 250, 254),
        };

        public override Color RarityColor => colors[(index++)%colors.Length];
    }
}