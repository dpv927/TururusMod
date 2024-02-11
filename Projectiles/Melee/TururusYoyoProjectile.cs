using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
    }
}
