using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TururusMod.Dusts {

    public class BrightDust : ModDust {

        public override void OnSpawn(Dust dust) {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, 0, 19, 19);
            dust.scale *= 0.75f;
            dust.noLight = false;
        }

        public override bool Update(Dust dust) {
            dust.position += dust.velocity;
            dust.scale -= 0.01f;

            if (dust.scale < 0.5f)
                dust.active = false;
            return false;
        }
    }
}
