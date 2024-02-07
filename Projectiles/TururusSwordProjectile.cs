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
                if(Projectile.ai[0] >= 180) {
                    Projectile.Kill();
                }
            }

            float rotateSpeed = 0.7f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;
            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);

            if(Main.rand.NextBool(2)) {
                int numToSpawn = Main.rand.Next(3);
                for(int i =0; i<numToSpawn; i++) {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, Projectile.velocity.X * 0.1f, Projectile.velocity.Y *0.1f, 
                        0, default(Color), 1f);
                }
             }
		}

        public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(0.5f).WithPitchOffset(0.8f), Projectile.position);
			for (var i = 0; i < 6; i++) {
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, 0f, 0f, 0, default(Color), 1f);
            }
        }
    }
}