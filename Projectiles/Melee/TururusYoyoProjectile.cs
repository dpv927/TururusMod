using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Dusts;

namespace TururusMod.Projectiles.Melee {

    public class TururusYoyoProjectile : ModProjectile {

        public override void SetDefaults() {
            Projectile.width = 30;
            Projectile.height = 26;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
        }

        public override void PostAI() {
            if (Main.rand.NextBool(2)) {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<BrightDust>());
            }
        }
    }
}
