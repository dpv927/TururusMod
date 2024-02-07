using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TururusMod.Projectiles {

    public class TururusSwordProjectile : ModProjectile {

        public override void SetDefaults() {
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 113;
			Projectile.height = 112;
			Projectile.aiStyle = -1;
            Projectile.timeLeft = 99999;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}

        public override void AI() {
            Projectile.ai[0]++;

            if(Projectile.ai[0] < 60f) {
                Projectile.velocity *= 1.01f;
            } else {
                Projectile.velocity *= 1.05f;
                if(Projectile.ai[0] >= 180)
                {
                    Projectile.Kill();
                }
            }

            float rotateSpeed = 0.35f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;
            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }

        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(0.5f).WithPitchOffset(0.8f), Projectile.position);
        }
    }
}