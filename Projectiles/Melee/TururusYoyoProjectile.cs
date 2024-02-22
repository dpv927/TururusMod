using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TururusMod.Dusts;

namespace TururusMod.Projectiles.Melee {

    public class TururusYoyoProjectile : ModProjectile {
        
        public const int MaxUpdates = 3;

        public override void SetStaticDefaults() {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 560f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 54f/MaxUpdates;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        public override void SetDefaults() {
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.width = Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.MaxUpdates = MaxUpdates;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 6 * MaxUpdates;
        }

        public override void AI() {
            if ((Projectile.position - Main.player[Projectile.owner].position).Length() > 3200f)
                Projectile.Kill();
        }

        public override void PostAI() {
            if (Main.rand.NextBool(2))
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<BrightDust>());
        }
    }
}
