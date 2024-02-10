using Terraria;
using Terraria.ModLoader;

namespace TururusMod.Projectiles.Melee
{

    public class SwordProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 113;
            Projectile.height = 112;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 100;
            Projectile.light = 0.8f;
        }

        public override void AI()
        {
            Projectile.ai[0]++;

            if (Projectile.ai[0] < 60f)
            {
                Projectile.velocity *= 1.01f;
            }
            else
            {
                Projectile.velocity *= 1.05f;
                if (Projectile.ai[0] >= 180)
                {
                    Projectile.Kill();
                }
            }

            float rotateSpeed = 0.35f * Projectile.direction;
            Projectile.rotation += rotateSpeed;
            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }
    }
}